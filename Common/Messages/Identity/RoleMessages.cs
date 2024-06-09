namespace Common.Messages.Identity
{
    public class RoleMessages
    {
        //Error Messages
        public readonly static string ErrorAdded = "Error al guardar el rol, verifique que los datos ingresados sean válidos y correctos.";
        public readonly static string ErrorDeleted = "Error al intentar eliminar el rol, comuníquese con el administrador.";
        public readonly static string ErrorUpdated = "Error al editar el rol, verifique que los datos ingresados sean válidos y correctos.";
        public readonly static string ErrorGetRoles = "Error al obtener la lista de roles.";

        // Success Messages
        public readonly static string SuccessfullyAdded = "Rol registrado con éxito.";
        public readonly static string SuccessfullyDeleted = "Rol eliminado con éxito.";
        public readonly static string SuccessfullyUpdated = "Rol actualizado con éxito.";

        // Warning Messages
        public readonly static string ExistingRole = "El rol ya existe, intente con otro.";
        public readonly static string EmptyRoles = "No se encontraron roles.";
        public readonly static string RoleNotFound = "El rol no se ha encontrado.";
        public readonly static string RoleIsEnrolled = "El rol se encuentra asignado a un usuario y no se puede eliminar.";
    }
}
