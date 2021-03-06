USE [EmployerRecord]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeIn] [nvarchar](max) NULL,
	[TimeOut] [nvarchar](max) NULL,
	[EmployeeId] [int] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Date] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL CONSTRAINT [DF_Attendance_DateCreated]  DEFAULT (getutcdate()),
	[Status] [int] NOT NULL CONSTRAINT [DF_Attendance_Status]  DEFAULT ((1)),
	[lat] [nvarchar](max) NULL,
	[lon] [nvarchar](max) NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Qrcode] [nvarchar](max) NOT NULL,
	[pin] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NULL,
	[username] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL CONSTRAINT [DF_Company_DateCreated]  DEFAULT (getutcdate()),
	[Status] [int] NOT NULL CONSTRAINT [DF_Company_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Contact] [nvarchar](max) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[username] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[hourrate] [nvarchar](max) NOT NULL,
	[active] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL CONSTRAINT [DF_Employee_DateCreated]  DEFAULT (getutcdate()),
	[Status] [int] NOT NULL CONSTRAINT [DF_Employee_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[InsertAttendance]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertAttendance]

@TimeIn NVARCHAR(MAX),
@EmployeeId int,
@Type NVARCHAR(MAX),
@Date NVARCHAR(MAX),
@lat NVARCHAR(MAX),
@lon NVARCHAR(MAX)

AS
BEGIN
IF NOT EXISTS (
	       SELECT e.Id
	       FROM   Attendance e
	       WHERE  e.EmployeeId= @EmployeeId and [Status]=2
	   )

BEGIN

INSERT INTO [dbo].[Attendance]
           (TimeIn,
           EmployeeId,[Type],[Date],lat,lon
           ,[Status])
     VALUES
           (@TimeIn,@EmployeeId,@Type ,@Date,@lat,@lon
           ,2)

	    SELECT SCOPE_IDENTITY()
	END
	ELSE
		SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[InsertCompany]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertCompany]

@Name NVARCHAR(MAX),
@Phone NVARCHAR(MAX),
@pin NVARCHAR(MAX),
@username NVARCHAR(MAX),
@password NVARCHAR(MAX),
@Qrcode NVARCHAR(MAX)

AS
BEGIN
IF NOT EXISTS (
	       SELECT c.username
	       FROM   Company C
	       WHERE  C.username = @username  and [Status]=1  
	   )

BEGIN

INSERT INTO [dbo].[Company]
           (Name,
           Phone,
           pin,[password],Qrcode,username
           ,[Status])
     VALUES
           (@Name
           ,@Phone,@pin ,@password,@Qrcode,@username
           ,1)

	    SELECT SCOPE_IDENTITY()
	END
	ELSE
		SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertEmployee]

@Name NVARCHAR(MAX),
@Contact NVARCHAR(MAX),
@CompanyId int,
@username NVARCHAR(MAX),
@password NVARCHAR(MAX),
@hourrate NVARCHAR(MAX),
@active NVARCHAR(MAX)

AS
BEGIN
IF NOT EXISTS (
	       SELECT e.username
	       FROM   Employee e
	       WHERE  e.username= @username    and [Status]=1
	   )

BEGIN

INSERT INTO [dbo].[Employee]
           (Name,
           Contact,
           CompanyId,username,[password],hourrate,active
           ,[Status])
     VALUES
           (@Name
           ,@Contact,@CompanyId,@username ,@password,@hourrate,@active
           ,1)

	    SELECT SCOPE_IDENTITY()
	END
	ELSE
		SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[SelectAttendance]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectAttendance]


AS
BEGIN


Select * from Attendance
	

END

GO
/****** Object:  StoredProcedure [dbo].[SelectAttendanceByEmpId]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectAttendanceByEmpId]

@EmpId int
AS
BEGIN


Select * from Attendance where EmployeeId=@EmpId and [Status]=1
	

END

GO
/****** Object:  StoredProcedure [dbo].[SelectAttendanceById]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectAttendanceById]

@Id int
AS
BEGIN


Select * from Attendance where Id=@Id and [Status]=1
	

END

GO
/****** Object:  StoredProcedure [dbo].[SelectCompany]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectCompany]

AS
BEGIN


Select * from Company where [Status]=1
	

END

GO
/****** Object:  StoredProcedure [dbo].[SelectCompanyById]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectCompanyById]

@Id int
AS
BEGIN


Select * from Company where Id=@Id and [Status]=1
	

END

GO
/****** Object:  StoredProcedure [dbo].[SelectCompanyByUserPass]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SelectCompanyByUserPass]

@Username NVARCHAR(MAX),
@Password NVARCHAR(MAX)
AS
BEGIN


Select * from Company where username=@Username and [password]= @Password and [Status]=1
	

END

GO
/****** Object:  StoredProcedure [dbo].[SelectEmployee]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectEmployee]


AS
BEGIN


Select * from Employee where [Status]=1
	

END

GO
/****** Object:  StoredProcedure [dbo].[SelectEmployeeById]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectEmployeeById]

@Id int
AS
BEGIN


Select * from Employee where Id=@Id and [Status]=1
	

END

GO
/****** Object:  StoredProcedure [dbo].[SelectEmployeeByUserPass]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SelectEmployeeByUserPass]

@Username NVARCHAR(MAX),
@Password NVARCHAR(MAX)
AS
BEGIN


Select * from Employee where username=@Username and [password]= @Password and [Status]=1
	

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateAttendance]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAttendance]
--@Id int=NULL,
--@TimeIn NVARCHAR(MAX)=NULL,
@TimeOut NVARCHAR(MAX)=NULL,
@EmployeeId int=NULL,
@Type NVARCHAR(MAX)=NULL,
@Date NVARCHAR(MAX)=NULL,
--@Status int,
@lat NVARCHAR(MAX)=null,
@lon NVARCHAR(MAX)=null

AS
BEGIN
IF EXISTS (
	       SELECT e.Id
	       FROM   Attendance e
	       WHERE  e.EmployeeId= @EmployeeId and [Status]=2
	   )

BEGIN
UPDATE [dbo].[Attendance]
   SET [TimeOut] = Case when @TimeOut IS NULL THEN [TimeOut] else @TimeOut END
	  ,EmployeeId=Case when @EmployeeId IS NULL THEN EmployeeId else @EmployeeId END
      ,[Type] = Case when @Type IS NULL THEN [Type] else @Type END
      ,[Date] = Case when @Date IS NULL THEN [Date] else @Date END
	  ,lat=Case when @lat IS NULL THEN lat else @lat END
		   ,lon=Case when @lon IS NULL THEN lon else @lon END
      ,[Status] = 3
	WHERE  EmployeeId= @EmployeeId and [Status]=2
	 SELECT @@ROWCOUNT
	 END
	ELSE
		SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCompany]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[UpdateCompany]

@Id int,
@Phone NVARCHAR(MAX)=null,
@pin NVARCHAR(MAX)=null,
@password NVARCHAR(MAX)=null,
@Status int=null
AS
BEGIN


Update [dbo].[Company]
           set 
           Phone=Case when @Phone IS NULL THEN Phone else @Phone END
           ,pin=Case when @pin IS NULL THEN pin else @pin END
		   ,[password]=Case when @password IS NULL THEN [password] else @password END
           ,[Status]=Case when @Status IS NULL THEN [Status] else @Status END
		   where Id=@Id
	    SELECT @@ROWCOUNT
	

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 2017-04-07 3:54:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployee]
@Id int,

@Contact NVARCHAR(MAX)=null,
--@CompanyId int,
--@username NVARCHAR(MAX),
@password NVARCHAR(MAX)=null,
@hourrate NVARCHAR(MAX)=null,
@active NVARCHAR(MAX)=null,
@Status int=null
AS
BEGIN

Update [dbo].[Employee]
           set
           Contact = Case when @Contact IS NULL THEN Contact else @Contact END
           
		   
		   ,[password]=Case when @password IS NULL THEN [password] else @password END
		   ,hourrate=Case when @hourrate IS NULL THEN hourrate else @hourrate END
		   ,active =Case when @active IS NULL THEN active else @active END
		   
           ,[Status]=Case when @Status IS NULL THEN [Status] else @Status END
		   where Id=@Id
		   Select @@ROWCOUNT
    

	

END

GO
