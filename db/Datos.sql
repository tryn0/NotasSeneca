-- Alumnos
INSERT INTO alumnos (nombre, apellidos, telefono, direccion, telefono_emergencia) VALUES('Juan Antonio', 'Gutierrez V�lez', 954800154, 'Calle Pirolis 10', 601028070);
INSERT INTO alumnos (nombre, apellidos, telefono, direccion, telefono_emergencia) VALUES('Isabel', 'Valles Lobato', 954097521, 'Calle Francisco Herrera 81 1B', 693017854);
INSERT INTO alumnos (nombre, apellidos, telefono, dni_alumno, direccion, telefono_emergencia) VALUES('Luc�a', 'Hern�ndez Saabedra', 954700250, '28104818Z', 'Calle Pablo Iglesias 28', 699395745);
INSERT INTO alumnos (nombre, apellidos, telefono, direccion, telefono_emergencia) VALUES('Zeus', 'Espinosa De la Cuadra', 954000690, 'Av. Juan Pablo II 123', 601478471);
INSERT INTO alumnos (nombre, apellidos, telefono, direccion, telefono_emergencia) VALUES('Mikel', 'Saboya Duque', 954001783, 'Calle Arroyo 5', 612894750);
INSERT INTO alumnos (nombre, apellidos, telefono, dni_alumno, direccion, telefono_emergencia) VALUES('Pablo', 'Garc�a L�pez', 954789001, '51887030X', 'Calle Murcia 17', 689200140);
INSERT INTO alumnos (nombre, apellidos, telefono, direccion, telefono_emergencia) VALUES('Rub�n', 'Blanco R�os', 954789897, 'Calle Malparado 9', 689300840);
INSERT INTO alumnos (nombre, apellidos, telefono, dni_alumno ,direccion, telefono_emergencia) VALUES('Sandra Mar�a', 'Marqu�z Alfalfa', 954777023, '88039111W', 'Calle Rioja 21 Atico B', 600397514);
INSERT INTO alumnos (nombre, apellidos, telefono, dni_alumno, direccion, telefono_emergencia) VALUES('Luisa', 'Laguna Valencia', 954030178, '87458102R', 'Calle Estrella Betelgeuse 25 2C', 698035741);
INSERT INTO alumnos (nombre, apellidos, telefono, direccion, telefono_emergencia) VALUES('Marina', 'Barbero Berenguel', 954825703, 'Calle Mar�a Laffitte 127 3A', 693698510);

-- Profesores
INSERT INTO profesores VALUES('Virginia', 'Merch�n Ru�z', 601782394, '96358745R', '132', 'Calle Rampamp�n 32');
INSERT INTO profesores VALUES('Samuel', 'L�pez Guevara', 698712048, '85214792V','123', 'Avenida de la Raza 47');
INSERT INTO profesores VALUES('Gonzalo', 'Ribera de Arag�n', 695721036, '98410257S','321', 'Paseo de Col�n 121');

-- Asignaturas
INSERT INTO asignaturas VALUES('Geograf�a', 'Ense�anzas del mundo, tanto pol�tica como f�sicamente',3);
INSERT INTO asignaturas VALUES('Inform�tica', 'Ense�anza de la inform�tica',2);
INSERT INTO asignaturas VALUES('Desarrollo de Interfaces Web', 'Ense�anza de interfaces gr�ficas de usuario, lo que el usuario ve',2);
INSERT INTO asignaturas VALUES('Matem�ticas', 'Matem�ticas, �lgebra, ecuaciones y gr�ficos',1);
INSERT INTO asignaturas VALUES('Desarrollo Web Entorno Servidor', 'Programaci�n orientada al servdiro, back-end',1);
INSERT INTO asignaturas VALUES('Ingl�s', 'Ense�anza de lengua extranjera',3);
INSERT INTO asignaturas VALUES('Base de Datos', 'Programaci�n de bases de datos',1);
INSERT INTO asignaturas VALUES('Desarrolo de Interfaces', 'Creaci�n de interfaces gr�ficas para el usuario, multiplataforma',2);

-- Clases
INSERT INTO clases (nombre) VALUES('1� DAW');
INSERT INTO clases (nombre) VALUES('2� DAW');
INSERT INTO clases (nombre) VALUES('1� DAM');
INSERT INTO clases (nombre) VALUES('2� DAM');
INSERT INTO clases (nombre) VALUES('1� ESO');
INSERT INTO clases (nombre) VALUES('4� ESO');

-- Clases_asignaturas
INSERT INTO clases_asignaturas VALUES(1, 7); -- 1,7
INSERT INTO clases_asignaturas VALUES(2, 3); -- 2,3
INSERT INTO clases_asignaturas VALUES(2, 5); -- 2,5
INSERT INTO clases_asignaturas VALUES(3, 7); -- 3,7
INSERT INTO clases_asignaturas VALUES(4, 8); -- 4,8
INSERT INTO clases_asignaturas VALUES(5, 1); -- 5,1
INSERT INTO clases_asignaturas VALUES(5, 6); -- 5,6
INSERT INTO clases_asignaturas VALUES(6, 6); -- 6,6
INSERT INTO clases_asignaturas VALUES(6, 2); -- 6,2

-- Clases_alumnos
INSERT INTO clases_alumnos VALUES(1,3);
INSERT INTO clases_alumnos VALUES(2,6);
INSERT INTO clases_alumnos VALUES(3,8);
INSERT INTO clases_alumnos VALUES(4,9);
INSERT INTO clases_alumnos VALUES(5,1);
INSERT INTO clases_alumnos VALUES(5,2);
INSERT INTO clases_alumnos VALUES(5,10);
INSERT INTO clases_alumnos VALUES(6,4);
INSERT INTO clases_alumnos VALUES(6,5);
INSERT INTO clases_alumnos VALUES(6,7);