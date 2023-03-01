using webapi.Modelos;

namespace Curso_Api_Rest.Services
{
    public class CategoriasServices: ICategoriaService
    {
        TareasContext context;

        public CategoriasServices(TareasContext dbcontext) {

            context = dbcontext;
        
        
        }


        public IEnumerable<Categoria> Get() {


            return context.Categorias;
        
        }

        public async Task Save(Categoria categoria) {
            context.Categorias.Add(categoria);

           await context.SaveChangesAsync();



        }
        public async Task Update(Guid id, Categoria categoria) { 
        var categoria_AcT= context.Categorias.Find(id);

            if (categoria_AcT != null) {
                categoria_AcT.Descripcion = categoria.Descripcion;
                categoria_AcT.Nombre = categoria.Nombre;
                categoria_AcT.Peso = categoria.Peso;
                await context.SaveChangesAsync();
            
            }
        
        
        
        }

        public async Task Delete(Guid id_categoria) {
            var categoria_Actual = context.Categorias.Find(id_categoria);
            if (categoria_Actual!= null) {

                context.Categorias.Remove(categoria_Actual);

                await context.SaveChangesAsync();
            
            
            }
       }
    }
    public interface ICategoriaService {
        
        
        IEnumerable<Categoria> Get();
        Task Save(Categoria categoria);
        Task Update(Guid id, Categoria categoria);
        Task Delete(Guid id_categoria);




    }
}
