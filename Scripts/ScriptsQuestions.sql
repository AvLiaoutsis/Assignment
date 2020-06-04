-- Create a script that will add an attribute of type 'Weight' and with a value set to 'Thin' to all employees.
-- If an employee already has a 'Weight' attribute, update that attribute, otherwise create a new one.

DECLARE @attr varchar(50);         
SELECT @attr =  ATTR_ID    from dbo.Attribute where attr_name ='Weight' AND attr_value ='Thin';


begin tran
if exists
(
select * from dbo.EmployeeAttribute AS RemainWeights
		INNER  JOIN  dbo.Attribute  
		ON EMPATTR_AttributeID = attr_id
		WHERE  attr_name ='Weight' 
)
begin
		UPDATE dbo.EmployeeAttribute SET  EMPATTR_AttributeID = @attr 
		FROM dbo.EmployeeAttribute
		INNER  JOIN  dbo.Attribute  
		ON EMPATTR_AttributeID = attr_id
		WHERE  attr_name ='Weight'  AND attr_value !='Thin'
end
else
begin
		INSERT INTO dbo.EmployeeAttribute
		SELECT EMP_ID,@attr
		FROM 
		dbo.Employee As employee
		LEFT JOIN dbo.EmployeeAttribute as jointable
		ON jointable.EMPATTR_EmployeeID = employee.EMP_ID
		WHERE EMPATTR_AttributeId  != @attr
end
commit tran


-- Create a script that will add an attribute of type 'Height' and with a value set to 'Short' to all employees that are supervisors of anybody else.
-- If an employee already has a 'Height' attribute, update that attribute, otherwise create a new one.


DECLARE @attr varchar(50);         
SELECT @attr =  ATTR_ID    from dbo.Attribute where attr_name ='Height' AND attr_value ='Short';

begin tran
if exists
(
select * from dbo.EmployeeAttribute AS RemainWeights
		INNER  JOIN  dbo.Attribute  
		ON EMPATTR_AttributeID = attr_id
		WHERE  attr_name ='Height' 
)
begin
		UPDATE dbo.EmployeeAttribute SET  EMPATTR_AttributeID = @attr 
		FROM dbo.EmployeeAttribute
		INNER  JOIN  dbo.Attribute  
		ON EMPATTR_AttributeID = attr_id
		WHERE  attr_name ='Height'  AND attr_value !='Short'
end
else
begin
		INSERT INTO dbo.EmployeeAttribute
		SELECT Distinct(EMP_ID),@attr
		FROM 
		dbo.Employee As employee
		LEFT JOIN dbo.EmployeeAttribute as jointable
		ON jointable.EMPATTR_EmployeeID = employee.EMP_ID
		WHERE EMPATTR_AttributeId  != @attr AND EMP_ID in (SELECT EMP_Supervisor FROM dbo.Employee WHERE  EMP_Supervisor IS NOT NULL)
end
commit tran


-- Create a script that will expect whoever runs it to provide an employee id. 
-- Locate all employees that the provided employee supervises in any depth. 
-- Add to these employee an attribute with a type of 'Team' and a value of the name of the originally provided supervising employee


 ALTER  PROCEDURE CreateTeam
(
    @id uniqueidentifier
)
AS
BEGIN
		INSERT INTO dbo.Attribute VALUES( NEWID(),'TEAM',@id)

		DECLARE @attr varchar(50);         
		SELECT @attr =  ATTR_ID    from dbo.Attribute where attr_name ='TEAM' AND attr_value =@id;

		INSERT INTO dbo.EmployeeAttribute
		SELECT EMP_ID,@attr
		FROM 
		dbo.Employee As employee
		LEFT JOIN dbo.EmployeeAttribute as jointable
		ON jointable.EMPATTR_EmployeeID = employee.EMP_ID
		WHERE EMPATTR_AttributeId  != @attr AND EMP_Supervisor = @id
END