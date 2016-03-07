/* Copyright 2016 Bouvet ASA 

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License. */

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Sesam.Templates.CustomDataSource.DataAccess
{
    /* An example repository implementation. 
       Exposes a stream of in memory entities
       that can be used as an example feed. */
    public class ExampleRepository : IRepository { 
        
        private List<ExampleEntity> _entities;
        private readonly ILogger<ExampleRepository> _logger;
        
        public ExampleRepository(ILogger<ExampleRepository> logger) {
            _logger = logger;            
            _entities = new List<ExampleEntity>();
            
            // add some example entities to the repository
            var entityCount = 100;
            for (var i=0;i<entityCount;i++) {
                var id = "e-" + i;
                var entity = new ExampleEntity(id);
                
                // we will use string comparison of ISO encoded date as string
                // to determine items.
                entity._updated = DateTime.UtcNow.ToString("o");
                entity.Name = "entity number " + i;
                _entities.Add(entity);
            }            
        }
        
        /*
           returns a single entity with the specified id, or null 
           if it doesn't exist.
        */       
        public Entity GetEntity(string id){
            if (id == null) return null;
            var entity = _entities.FirstOrDefault(x => x._id == id);
            return entity;
        }       
               
        /*
            return an IEnumerable of entities filtered by when they 
            were created, deleted, or modified.
        */
        public IEnumerable<Entity> GetEntities(string since = null){
            if (since == null) return _entities; 
            return _entities.Where(x => String.Compare(x._updated, since) >= 0);
        }         
    }   
}

