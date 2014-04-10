/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2014/3/27 9:07:20                            */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('t_pm_orgcommittee') and o.name = 'FK_ORG_REFERENCE_COMMITTEE')
alter table t_pm_orgcommittee
   drop constraint FK_ORG_REFERENCE_COMMITTEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('t_sys_department') and o.name = 'FK_Department_REFERENCE_departmenttype')
alter table t_sys_department
   drop constraint FK_Department_REFERENCE_departmenttype
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('t_sys_member') and o.name = 'FK_MEMBER_REFERENCE_EDUTION')
alter table t_sys_member
   drop constraint FK_MEMBER_REFERENCE_EDUTION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('t_sys_member') and o.name = 'FK_MEMBER_REFERENCE_NATION')
alter table t_sys_member
   drop constraint FK_MEMBER_REFERENCE_NATION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('t_sys_member') and o.name = 'FK_MEMBER_REFERENCE_DEPARTMENT')
alter table t_sys_member
   drop constraint FK_MEMBER_REFERENCE_DEPARTMENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('t_pm_orgcommittee')
            and   type = 'U')
   drop table t_pm_orgcommittee
go

if exists (select 1
            from  sysobjects
           where  id = object_id('t_pm_orginfo')
            and   type = 'U')
   drop table t_pm_orginfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('t_sys_department')
            and   type = 'U')
   drop table t_sys_department
go

if exists (select 1
            from  sysobjects
           where  id = object_id('t_sys_departmenttype')
            and   type = 'U')
   drop table t_sys_departmenttype
go

if exists (select 1
            from  sysobjects
           where  id = object_id('t_sys_education')
            and   type = 'U')
   drop table t_sys_education
go

if exists (select 1
            from  sysobjects
           where  id = object_id('t_sys_member')
            and   type = 'U')
   drop table t_sys_member
go

if exists (select 1
            from  sysobjects
           where  id = object_id('t_sys_nation')
            and   type = 'U')
   drop table t_sys_nation
go

/*==============================================================*/
/* Table: t_pm_orgcommittee                                     */
/*==============================================================*/
create table t_pm_orgcommittee (
   FCommitteeID         bigint               identity,
   FOrgId               bigint               not null,
   FCommitteeName       varchar(100)         not null,
   FCommitteePosition   char(1)              not null default '3'
      constraint CKC_FCOMMITTEEPOSITIO_T_PM_ORG check (FCommitteePosition in ('1','2','3')),
   FCommitteeMobile     varchar(20)          not null,
   FCommitteeTel        varchar(20)          null,
   FCommitteeOrder      int                  not null default 10,
   constraint PK_T_PM_ORGCOMMITTEE primary key (FCommitteeID)
)
go

/*==============================================================*/
/* Table: t_pm_orginfo                                          */
/*==============================================================*/
create table t_pm_orginfo (
   FOrgId               bigint               identity,
   FOrgName             varchar(200)         not null,
   FParentOrgId         bigint               null,
   FOrgType             char(1)              not null
      constraint CKC_FORGTYPE_T_PM_ORG check (FOrgType in ('1','2','3')),
   FOrgNewDate          datetime             not null,
   FOrgOrder            int                  not null default 10,
   constraint PK_T_PM_ORGINFO primary key (FOrgId)
)
go

/*==============================================================*/
/* Table: t_sys_department                                      */
/*==============================================================*/
create table t_sys_department (
   FDepartmentID        bigint               identity,
   FDepartmentTypeId    bigint               not null,
   FDepartmentCode      varchar(20)          not null,
   FDepartmentName      varchar(200)         not null,
   FDepartmentCharge    varchar(100)         null,
   FDepartmentNum       int                  not null default 1,
   FDepartmentTel       varchar(30)          null,
   FDepartmentContent   text                 null,
   constraint PK_T_SYS_DEPARTMENT primary key (FDepartmentID)
)
go

/*==============================================================*/
/* Table: t_sys_departmenttype                                  */
/*==============================================================*/
create table t_sys_departmenttype (
   FDepartmentTypeId    bigint               identity,
   FDepartmentTypeName  varchar(200)         not null,
   FDepartmentTypeOrder int                  not null default 10,
   constraint PK_T_SYS_DEPARTMENTTYPE primary key (FDepartmentTypeId)
)
go

/*==============================================================*/
/* Table: t_sys_education                                       */
/*==============================================================*/
create table t_sys_education (
   FEductionID          bigint               not null,
   FEductionName        varchar(50)          not null,
   FEductionOrder       int                  not null default 10,
   constraint PK_T_SYS_EDUCATION primary key (FEductionID)
)
go

/*==============================================================*/
/* Table: t_sys_member                                          */
/*==============================================================*/
create table t_sys_member (
   FMemberId            bigint               identity,
   FEductionID          bigint               not null,
   FNationID            bigint               not null,
   FDepartmentID        bigint               not null,
   FMemberName          varchar(50)          not null,
   FMemberGendor        char(1)              not null default '0'
      constraint CKC_FMEMBERGENDOR_T_SYS_ME check (FMemberGendor in ('0','1')),
   FBirthDate           datetime             not null,
   FIDNumber            varchar(30)          not null,
   FMobile              varchar(30)          not null,
   FPosition            varchar(50)          null,
   FPicPath             varchar(200)         null,
   FStatus              char(1)              not null default '1'
      constraint CKC_FSTATUS_T_SYS_ME check (FStatus in ('1','0','2')),
   constraint PK_T_SYS_MEMBER primary key (FMemberId)
)
go

/*==============================================================*/
/* Table: t_sys_nation                                          */
/*==============================================================*/
create table t_sys_nation (
   FNationID            bigint               identity,
   FNationName          varchar(200)         not null,
   FNationOrder         int                  not null default 10,
   constraint PK_T_SYS_NATION primary key (FNationID)
)
go

alter table t_pm_orgcommittee
   add constraint FK_ORG_REFERENCE_COMMITTEE foreign key (FOrgId)
      references t_pm_orginfo (FOrgId)
go

alter table t_sys_department
   add constraint FK_Department_REFERENCE_departmenttype foreign key (FDepartmentTypeId)
      references t_sys_departmenttype (FDepartmentTypeId)
go

alter table t_sys_member
   add constraint FK_MEMBER_REFERENCE_EDUTION foreign key (FEductionID)
      references t_sys_education (FEductionID)
go

alter table t_sys_member
   add constraint FK_MEMBER_REFERENCE_NATION foreign key (FNationID)
      references t_sys_nation (FNationID)
go

alter table t_sys_member
   add constraint FK_MEMBER_REFERENCE_DEPARTMENT foreign key (FDepartmentID)
      references t_sys_department (FDepartmentID)
go

