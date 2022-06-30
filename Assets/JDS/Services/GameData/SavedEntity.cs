using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Leopotam.Ecs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;

[Serializable]
public class SavedEntity
{
    public static MethodInfo ToObjectMethod;

   static SavedEntity()
   {
       ToObjectMethod = typeof(JObject)
           .GetMethods().First(x => x.IsGenericMethod && x.Name == "ToObject" && x.GetParameters().Length == 0);
   }
   
    public List<SavedComponent> ComponentsList;

    public SavedEntity(EcsEntity entity)
    {
        SaveFrom(entity);
    }
    
    public void SaveFrom(EcsEntity entity)
    {
        if (entity.IsNull())
        {
            return;
        }
        var components = new object[entity.GetComponentsCount()];
        entity.GetComponentValues(ref components);


        ComponentsList = components.Where(x => x is ISavable).Select(o => new SavedComponent()
        {
            Type = o.GetType().Name,
            Data = ((ISavable)o).Save()
        }).ToList();
    }

    public List<SavedComponent> Components
    {
        get
        {
            return ComponentsList;
        }
        set
        {


            ComponentsList = value;
            
            return;
            
         //   _componentsList = new List<SavedComponent>();
            foreach (var loadedComponent in value)
            {
                //var component = JsonConvert.DeserializeObject(loadedComponent.)
                var type = Type.GetType(loadedComponent.Type);

                object jObject = null;


                var x2 = ToObjectMethod.MakeGenericMethod(type);

                try
                {
                    var x3 = x2.Invoke(jObject, null);
                   // _componentsList.Add(x3);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }
    }
}