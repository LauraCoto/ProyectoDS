
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
	 
	 
--insert into dbo.AspNetUserRoles(UserId,RoleId) values('a1e84734-a51b-4462-bc4e-395d7fa4c533','a691b6e4-b014-4a34-9ed9-7102c607292d')