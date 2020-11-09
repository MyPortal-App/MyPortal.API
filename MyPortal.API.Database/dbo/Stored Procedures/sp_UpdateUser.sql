
CREATE PROCEDURE [dbo].[sp_UpdateUser] (
    @Id int
	,@Username Nvarchar(30)
	,@PasswordHash nvarchar(30)
	,@PasswordSalt Nvarchar(30)
	,@Firstname Nvarchar(30)
	,@LastName Nvarchar(30)
	,@Age Nvarchar(30)
	,@Sex Nvarchar(30)
	,@Race Nvarchar(30)
	,@Designation Nvarchar(30)
	,@JobTitle Nvarchar(30)
	,@SalaryLevel int
	,@ChiefDirectorate Nvarchar(30)
	,@Directorate Nvarchar(30)
	,@SubDirectorate Nvarchar(30)
	,@OfficeLocation Nvarchar(30)
	,@ContactNumberOffice Nvarchar(30)
	,@ContactCell Nvarchar(30)
	,@AppointmentDate Nvarchar(30)
	,@ProbationPeriodstatus Nvarchar(30)
	,@InductionStatus Nvarchar(30)
	,@Manager Nvarchar(30)
	,@Highestqualification Nvarchar(30)
	,@HomeAddress Nvarchar(30)
	,@Maritalstatus Nvarchar(30)
	,@SpouseName Nvarchar(30)
	,@SpouseMaidenName Nvarchar(30)
	,@NextofKinName Nvarchar(30)
	,@NextofKinSurname Nvarchar(30)
	,@NextofKinRelation Nvarchar(30)
	,@Password Nvarchar(30)
	)
AS
	UPDATE 
		Users
	SET 
		Username                   = 	@Username 
		,PasswordHash              = 	@PasswordHash               
		,Firstname                 = 	@Firstname                  
		,LastName                  = 	@LastName                   
		,Age                       = 	@Age                        
		,Sex                       = 	@Sex                        
		,Race                      = 	@Race                       
		,Designation               = 	@Designation                
		,JobTitle                  = 	@JobTitle                   
		,SalaryLevel               = 	@SalaryLevel                
		,ChiefDirectorate          = 	@ChiefDirectorate           
		,Directorate               = 	@Directorate                
		,SubDirectorate            = 	@SubDirectorate             
		,OfficeLocation            = 	@OfficeLocation             
		,ContactNumberOffice       = 	@ContactNumberOffice        
		,ContactCell               = 	@ContactCell                
		,AppointmentDate           = 	@AppointmentDate            
		,ProbationPeriodstatus     = 	@ProbationPeriodstatus      
		,InductionStatus           = 	@InductionStatus            
		,Manager                   = 	@Manager                    
		,Highestqualification      = 	@Highestqualification       
		,HomeAddress               = 	@HomeAddress                
		,Maritalstatus             = 	@Maritalstatus              
		,SpouseName                = 	@SpouseName                 
		,SpouseMaidenName          = 	@SpouseMaidenName           
		,NextofKinName             = 	@NextofKinName              
		,NextofKinSurname          = 	@NextofKinSurname           
		,NextofKinRelation         = 	@NextofKinRelation          
		,[Password]                  = 	@Password 
	WHERE
		Id = @Id