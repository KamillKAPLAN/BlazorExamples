/* tblCustomer */
Create table tblCustomer (   
	CustomerId int IDENTITY(1,1) NOT NULL,   
	Name varchar(20) NOT NULL,   
	City varchar(20) NOT NULL,   
	Country varchar(20) NOT NULL,   
	Gender varchar(6) NOT NULL  
)
go
/* Stored Procedure Insert */
Create procedure sp_AddCustomer (
	@Name VARCHAR(20),
	@City VARCHAR(20),   
	@Country VARCHAR(20),   
	@Gender VARCHAR(6)   
)   
as    
Begin   
    Insert into tblCustomer (Name, City, Country, Gender) Values (@Name, @City, @Country, @Gender)    
End
go
/* Stored Procedure Select - GetAll */
Create procedure sp_GetAllCustomers
as   
Begin   
    SELECT CustomerId, Name, City, Country, Gender FROM tblCustomer   
End
go
/* Stored Procedure GetById */
Create procedure sp_GetByIdCustomer (    
    @CustomerId int
)    
as     
Begin     
    SELECT * FROM tblCustomer WHERE CustomerID = @CustomerId
End
go
/* Stored Procedure Update */
Create procedure sp_UpdateCustomer (
	@CustomerId INTEGER ,   
	@Name VARCHAR(20),    
	@City VARCHAR(20),   
	@Country VARCHAR(20),
	@Gender VARCHAR(6)   
)     
as    
Begin
	Update tblCustomer
	SET Name = @Name,     
	City = @City,     
	Country = @Country,   
	Gender = @Gender 
	WHERE CustomerId = @CustomerId     
End
go
/* Stored Procedure Delete */
Create procedure sp_DeleteCustomer (
	@CustomerId int     
)     
as      
Begin     
   Delete from tblCustomer where CustomerId = @CustomerId     
End
go
/* Employees */
  
CREATE TABLE [dbo].[Employees] (  
    [Id]          NVARCHAR (250) NOT NULL,  
    [Name]        NVARCHAR (250) NULL,  
    [Department]  NVARCHAR (250) NULL,  
    [Designation] NVARCHAR (250) NULL,  
    [Company]     NVARCHAR (250) NULL,  
    [City]        NVARCHAR (250) NULL,  
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC)  
);