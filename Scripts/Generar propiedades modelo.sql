

select 'public virtual '+case when c.DATA_TYPE like 'nvarchar' then ' string ' 
							  when c.DATA_TYPE like 'varchar' then ' string ' 
							  when c.DATA_TYPE like 'bigint' then ' long ' 
							  when c.DATA_TYPE like 'int' then ' int ' 
							  when c.DATA_TYPE like 'datetime' then ' DateTime ' 
							  when c.DATA_TYPE like 'bit' then ' bool ' 
						  else c.DATA_TYPE
					  end  +' '+ c.COLUMN_NAME +' { get; set; }' Propiedad
       ,*
  from INFORMATION_SCHEMA.COLUMNS c
 where c.TABLE_NAME ='ComplejoDeportivo'
 and c.COLUMN_NAME not in ('FechaCreo','FechaElimino','Activo','IdUsuario')