create table clientes
(
    id               int identity
        constraint clientes_pk
            primary key nonclustered,
    nombres          varchar(100) not null,
    apellidos        varchar(100) not null,
    dui              varchar(9)   not null,
    fecha_nacimiento date         not null
)
go

create unique index clientes_dui_uindex
    on clientes (dui)
go

INSERT INTO CLIENTES.dbo.clientes (id, nombres, apellidos, dui, fecha_nacimiento) VALUES (1, N'José David', N'Mejia Segura', N'000000000', N'1998-07-23');
