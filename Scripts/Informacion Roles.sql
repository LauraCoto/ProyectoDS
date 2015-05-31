
select * from dbo.AspNetUsers
select * from dbo.AspNetRoles
select * from dbo.AspNetUserRoles


select usuario.UserName
	   ,rol.Name 
 from dbo.AspNetUserRoles permiso
   	  inner join dbo.AspNetUsers usuario
	      	  on usuario.Id = permiso.UserId
	  inner join dbo.AspNetRoles rol
			  on rol.Id = permiso.RoleId
	

select * from dbo.aspnet_UsersInRoles



select * from dbo.AspNetUserRoles
