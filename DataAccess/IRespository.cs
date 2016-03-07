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

namespace Sesam.Templates.CustomDataSource.DataAccess
{
    /*
    A simple repository interface for fetching a stream 
    of entities and an individual entity.
    */
    public interface IRepository
    {
        IEnumerable<Entity> GetEntities(string since = null);
        Entity GetEntity(string id);
    }
}