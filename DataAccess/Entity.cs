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

namespace Sesam.Templates.CustomDataSource.DataAccess
{
    /* Base class that defines the entity properties 
       supported by the JSON Entities protocol. */   
    public abstract class Entity {   
        
        public Entity(string id) {
            _id = id;
        }
             
        public string _id {
            private set;
            get;
        }
        
        /* Updated is only used internally by the datasource. 
           It can be any token that the datasource can use
           to order entities */        
        public string _updated {
            get;set;
        }
        
        public bool _deleted {
            get;set;
        }                
    }
}