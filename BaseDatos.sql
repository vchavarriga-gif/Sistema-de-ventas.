/* =========================================================
   MODELO FÍSICO - SistemaVentas (MySQL 8.0.16 o superior)
   Ejecutar completo en MySQL Workbench (rayo ⚡ "Execute").
   Modelo en 3FN. Restricciones: PK, FK, CHECK, NOT NULL, UNIQUE.
   ========================================================= */

DROP DATABASE IF EXISTS SistemaVentas;
CREATE DATABASE SistemaVentas CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE SistemaVentas;

/* ---------- USUARIO (clase padre) ----------
   Tipo es el DISCRIMINADOR del patrón "tabla por subtipo":
   indica en qué tabla hija (Jefe o Trabajador) están sus datos. */
CREATE TABLE Usuario (
    Rut     VARCHAR(12)  NOT NULL,
    Nombre  VARCHAR(100) NOT NULL,
    Clave   VARCHAR(50)  NOT NULL,
    Tipo    VARCHAR(12)  NOT NULL,
    CONSTRAINT PK_Usuario        PRIMARY KEY (Rut),
    CONSTRAINT CK_Usuario_Tipo   CHECK (Tipo IN ('JEFE', 'TRABAJADOR')),
    CONSTRAINT CK_Usuario_Nombre CHECK (CHAR_LENGTH(Nombre) > 0)
);

/* ---------- JEFE (hereda de Usuario) ---------- */
CREATE TABLE Jefe (
    Rut         VARCHAR(12) NOT NULL,
    NivelAcceso INT         NOT NULL,
    CONSTRAINT PK_Jefe         PRIMARY KEY (Rut),
    CONSTRAINT FK_Jefe_Usuario FOREIGN KEY (Rut) REFERENCES Usuario(Rut) ON DELETE CASCADE,
    CONSTRAINT CK_Jefe_Nivel   CHECK (NivelAcceso BETWEEN 1 AND 3)
);

/* ---------- TRABAJADOR (hereda de Usuario) ---------- */
CREATE TABLE Trabajador (
    Rut     VARCHAR(12) NOT NULL,
    Turno   VARCHAR(10) NOT NULL,
    RutJefe VARCHAR(12) NULL,
    CONSTRAINT PK_Trabajador         PRIMARY KEY (Rut),
    CONSTRAINT FK_Trabajador_Usuario FOREIGN KEY (Rut)     REFERENCES Usuario(Rut) ON DELETE CASCADE,
    CONSTRAINT FK_Trabajador_Jefe    FOREIGN KEY (RutJefe) REFERENCES Jefe(Rut),
    CONSTRAINT CK_Trabajador_Turno   CHECK (Turno IN ('MAÑANA', 'TARDE', 'NOCHE'))
);

/* ---------- PRODUCTO ---------- */
CREATE TABLE Producto (
    IdProducto INT          NOT NULL AUTO_INCREMENT,
    Nombre     VARCHAR(100) NOT NULL,
    Precio     INT          NOT NULL,
    Stock      INT          NOT NULL DEFAULT 0,
    CONSTRAINT PK_Producto        PRIMARY KEY (IdProducto),
    CONSTRAINT UQ_Producto_Nombre UNIQUE (Nombre),
    CONSTRAINT CK_Producto_Precio CHECK (Precio > 0),
    CONSTRAINT CK_Producto_Stock  CHECK (Stock >= 0)
);

/* ---------- VENTA  (Trabajador 1 --REGISTRA-- N Venta) ---------- */
CREATE TABLE Venta (
    IdVenta       INT         NOT NULL AUTO_INCREMENT,
    Fecha         DATETIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    Total         INT         NOT NULL,
    RutTrabajador VARCHAR(12) NOT NULL,
    CONSTRAINT PK_Venta            PRIMARY KEY (IdVenta),
    CONSTRAINT FK_Venta_Trabajador FOREIGN KEY (RutTrabajador) REFERENCES Trabajador(Rut),
    CONSTRAINT CK_Venta_Total      CHECK (Total >= 0)
);

/* ---------- DETALLE_VENTA  (Venta N --CONTIENE-- M Producto) ----------
   PrecioUnitario = precio HISTÓRICO al momento de vender (no viola 3FN:
   depende de la venta, no del producto). Subtotal es columna calculada. */
CREATE TABLE DetalleVenta (
    IdVenta        INT NOT NULL,
    IdProducto     INT NOT NULL,
    Cantidad       INT NOT NULL,
    PrecioUnitario INT NOT NULL,
    Subtotal       INT GENERATED ALWAYS AS (Cantidad * PrecioUnitario) STORED,
    CONSTRAINT PK_DetalleVenta          PRIMARY KEY (IdVenta, IdProducto),
    CONSTRAINT FK_DetalleVenta_Venta    FOREIGN KEY (IdVenta)    REFERENCES Venta(IdVenta) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleVenta_Producto FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto),
    CONSTRAINT CK_DetalleVenta_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CK_DetalleVenta_Precio   CHECK (PrecioUnitario > 0)
);

/* ---------- DATOS DE PRUEBA ---------- */
INSERT INTO Usuario (Rut, Nombre, Clave, Tipo) VALUES
('11111111-1', 'Ana Jefa',       'admin123', 'JEFE'),
('22222222-2', 'Pedro Vendedor', 'pedro123', 'TRABAJADOR');

INSERT INTO Jefe (Rut, NivelAcceso) VALUES ('11111111-1', 3);
INSERT INTO Trabajador (Rut, Turno, RutJefe) VALUES ('22222222-2', 'MAÑANA', '11111111-1');

INSERT INTO Producto (Nombre, Precio, Stock) VALUES
('Pan amasado',    250,  100),
('Empanada pino',  1800, 40),
('Kuchen manzana', 6500, 10),
('Bebida 1.5L',    1900, 30);

SELECT * FROM Producto;
