namespace Service.Contracts
{
    public interface IPermissionService
    {
        //IEnumerable<> GetPermissions(bool tranckChanges);
        string GetRolesToken(string user, IJWTService jwtService);
    }
}
