/* Migration for tblUnits and related stored procedures */

-- 1) Rename typo columns to correct names
IF COL_LENGTH('dbo.tblUnits','MeasurmentUnitTitle') IS NOT NULL
    EXEC sp_rename 'dbo.tblUnits.MeasurmentUnitTitle', 'MeasurementUnitTitle', 'COLUMN';

IF COL_LENGTH('dbo.tblUnits','MesurmentUnitQuantity') IS NOT NULL
    EXEC sp_rename 'dbo.tblUnits.MesurmentUnitQuantity', 'MeasurementUnitQuantity', 'COLUMN';

-- 2) Tighten data types
IF COL_LENGTH('dbo.tblUnits','MeasurementUnitTitle') IS NOT NULL
    ALTER TABLE dbo.tblUnits ALTER COLUMN MeasurementUnitTitle NVARCHAR(200) NOT NULL;

IF COL_LENGTH('dbo.tblUnits','PUnitTitle') IS NOT NULL
    ALTER TABLE dbo.tblUnits ALTER COLUMN PUnitTitle NVARCHAR(200) NOT NULL;

-- 3) Create useful indexes
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_tblUnits_UnitType_isDeleted' AND object_id = OBJECT_ID('dbo.tblUnits'))
    CREATE NONCLUSTERED INDEX IX_tblUnits_UnitType_isDeleted
    ON dbo.tblUnits(UnitType, isDeleted)
    INCLUDE (MeasurementUnitTitle, PUnitTitle, isActive);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_tblUnits_Search' AND object_id = OBJECT_ID('dbo.tblUnits'))
    CREATE NONCLUSTERED INDEX IX_tblUnits_Search
    ON dbo.tblUnits(MeasurementUnitTitle, PUnitTitle)
    WHERE isDeleted = 0;

/* 4) Update stored procedures to use new column names */
GO
IF OBJECT_ID('dbo.sp_InsertUnit','P') IS NOT NULL DROP PROC dbo.sp_InsertUnit;
GO
CREATE PROC dbo.sp_InsertUnit
    @UnitType NVARCHAR(50),
    @MeasurementUnitTitle NVARCHAR(200),
    @MeasurementUnitQuantity INT,
    @PUnitTitle NVARCHAR(200),
    @PUnitQuantity INT,
    @isActive BIT,
    @CreatedBy NVARCHAR(50),
    @DATE NVARCHAR(10),
    @DATEVALUE INT,
    @DATEDIG NVARCHAR(8),
    @NewUnitID NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    -- Example code: generate new id and insert
    DECLARE @id NVARCHAR(50) = (SELECT dbo.fn_GenerateNewCode('tblUnits','UnitID','UN-'));
    INSERT INTO dbo.tblUnits(UnitID,UnitType,MeasurementUnitTitle,MeasurementUnitQuantity,PUnitTitle,PUnitQuantity,isActive,isDeleted)
    VALUES(@id,@UnitType,@MeasurementUnitTitle,@MeasurementUnitQuantity,@PUnitTitle,@PUnitQuantity,@isActive,0);
    SET @NewUnitID = @id;
END
GO

IF OBJECT_ID('dbo.sp_UpdateUnit','P') IS NOT NULL DROP PROC dbo.sp_UpdateUnit;
GO
CREATE PROC dbo.sp_UpdateUnit
    @UnitID NVARCHAR(50),
    @UnitType NVARCHAR(50),
    @MeasurementUnitTitle NVARCHAR(200),
    @MeasurementUnitQuantity INT,
    @PUnitTitle NVARCHAR(200),
    @PUnitQuantity INT,
    @isActive BIT,
    @UpdatedBy NVARCHAR(50),
    @DATE NVARCHAR(10),
    @DATEVALUE INT,
    @DATEDIG NVARCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblUnits
    SET UnitType = @UnitType,
        MeasurementUnitTitle = @MeasurementUnitTitle,
        MeasurementUnitQuantity = @MeasurementUnitQuantity,
        PUnitTitle = @PUnitTitle,
        PUnitQuantity = @PUnitQuantity,
        isActive = @isActive
    WHERE UnitID = @UnitID AND isDeleted = 0;

    SELECT CASE WHEN @@ROWCOUNT > 0 THEN 1 ELSE 0 END;
END
GO

IF OBJECT_ID('dbo.sp_DeleteUnit','P') IS NOT NULL DROP PROC dbo.sp_DeleteUnit;
GO
CREATE PROC dbo.sp_DeleteUnit
    @UnitID NVARCHAR(50),
    @DeletedBy NVARCHAR(50),
    @DATE NVARCHAR(10),
    @DATEVALUE INT,
    @DATEDIG NVARCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblUnits SET isDeleted = 1 WHERE UnitID = @UnitID;
    SELECT @@ROWCOUNT;
END
GO

IF OBJECT_ID('dbo.sp_ReturnAllUnits','P') IS NOT NULL DROP PROC dbo.sp_ReturnAllUnits;
GO
CREATE PROC dbo.sp_ReturnAllUnits
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UnitID, UnitType, MeasurementUnitTitle, MeasurementUnitQuantity, PUnitTitle, PUnitQuantity, isActive, isDeleted
    FROM dbo.tblUnits;
END
GO

IF OBJECT_ID('dbo.sp_SearchUnits','P') IS NOT NULL DROP PROC dbo.sp_SearchUnits;
GO
CREATE PROC dbo.sp_SearchUnits
    @Keyword NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UnitID, UnitType, MeasurementUnitTitle, MeasurementUnitQuantity, PUnitTitle, PUnitQuantity, isActive, isDeleted
    FROM dbo.tblUnits
    WHERE isDeleted = 0
      AND (
           UnitID LIKE '%' + @Keyword + '%'
        OR UnitType LIKE '%' + @Keyword + '%'
        OR MeasurementUnitTitle LIKE '%' + @Keyword + '%'
        OR PUnitTitle LIKE '%' + @Keyword + '%'
      );
END
GO
