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
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Sesam.Templates.CustomDataSource.DataAccess;
using Microsoft.Extensions.Logging;

namespace Sesam.Templates.CustomDataSource.Controllers
{    
    [Route("api/[controller]")]
    public class EntitiesController : Controller
    {
        private readonly IRepository _entityRepository;
        private readonly ILogger<EntitiesController> _logger;
        
        // Use dependency injected repository and logger as configured
        // in Startup.cs
        public EntitiesController(IRepository entityRepository, 
                                  ILogger<EntitiesController> logger){
            _entityRepository = entityRepository;            
            _logger = logger;
        }
        
        // GET: api/entities
        [HttpGet]
        public IEnumerable<Entity> GetEntities(string since)
        {            
            return _entityRepository.GetEntities(since);            
        }

        // GET api/entities/{id}
        [HttpGet("{id}")]
        public Entity GetEntity(string id)
        {
            return _entityRepository.GetEntity(id);
        }
    }
}
