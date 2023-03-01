using webapi.Modelos;

namespace Curso_Api_Rest.Services
{
    public class TareaServices: ITareaServices
    {
        TareasContext context;


        public TareaServices(TareasContext tareasContext) {


            context = tareasContext;
        
        }


        public IEnumerable<Tarea> Get() {



            return context.Tareas;
        }

        public async Task Save(Tarea Tarea , Guid id_categoria) {
            var categoria_Actual = context.Categorias.Find(id_categoria);
            if (categoria_Actual != null) {

                Tarea.CategoriaId = id_categoria;
                context.Tareas.AddAsync(Tarea);

                await context.SaveChangesAsync();
            
            
            }
        
        
        
        
        
        }
        public async Task Update(Guid id_tarea, Tarea tarea, Guid id_categoria) {


            var tarea_actual = context.Tareas.Find(id_tarea);
            var categoria = context.Categorias.Find(id_categoria);
            if (tarea_actual!=null && categoria!= null) {
                tarea_actual.FechaCreacion = tarea.FechaCreacion;
                tarea_actual.CategoriaId = id_categoria;
                tarea_actual.PrioridadTarea = tarea.PrioridadTarea;
                tarea_actual.Titulo = tarea.Titulo;
                tarea_actual.Resumen = tarea.Resumen;
                tarea_actual.Descripcion = tarea.Descripcion;

                await context.SaveChangesAsync();
            
            
            }
        
        
        
        }



        public async Task Delete(Guid id_tarea) {

       var     tarea_Actual = context.Tareas.Find(id_tarea);


            if (tarea_Actual != null) { 
            
            context.Tareas.Remove(tarea_Actual);

                await context.SaveChangesAsync();
            
            
            
            }
        
        
        
        
        }

    }


    public interface ITareaServices {

        IEnumerable<Tarea> Get();
        Task Save(Tarea Tarea, Guid id_categoria);
        Task Update(Guid id_tarea, Tarea tarea, Guid id_categoria);
        Task Delete(Guid id_tarea);



    }
}
