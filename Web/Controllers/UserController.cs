using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserViewBack.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize] // Asegura que todas las acciones de este controlador requieran autenticación
    public class UserController: ControllerBase
    {
        // Servicios necesarios para realizar operaciones de lectura y escritura
        private readonly ITodoTaskCommandService _todoItemCommandService;
        private readonly ITodoTaskQueryService _todoItemQueryService;

        // Constructor para inyectar dependencias
        public TodoTaskController(ITodoTaskCommandService todoItemCommandService, ITodoTaskQueryService todoItemQueryService)
        {
            _todoItemCommandService = todoItemCommandService;
            _todoItemQueryService = todoItemQueryService;
        }

        // -----------------------------------------------------------------------
        // Acciones de Lectura
    }
}
