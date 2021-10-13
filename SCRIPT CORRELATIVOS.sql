SET IDENTITY_INSERT [dbo].[tipoDocumento] ON 

INSERT [dbo].[tipoDocumento] ([IdTipDoc], [Descripcion],prefijo) VALUES (1, N'Recibo Provisional','141')
INSERT [dbo].[tipoDocumento] ([IdTipDoc], [Descripcion],prefijo) VALUES (2, N'Egreso de Caja','141')
INSERT [dbo].[tipoDocumento] ([IdTipDoc], [Descripcion],prefijo) VALUES (3, N'Ingreso de Caja','001')
INSERT [dbo].[tipoDocumento] ([IdTipDoc], [Descripcion],prefijo) VALUES (4, N'Jornada extraordinaria','001')
INSERT [dbo].[tipoDocumento] ([IdTipDoc], [Descripcion],prefijo) VALUES (5, N'Solicitud de descanso compensatorio','001')
SET IDENTITY_INSERT [dbo].[tipoDocumento] OFF
GO
SET IDENTITY_INSERT [dbo].[trabajador] ON 

INSERT [dbo].[trabajador] ([DNI], [nombre]) VALUES (N'45160485', N'Josue')
INSERT [dbo].[trabajador] ([IdTrabajador], [DNI], [nombre]) VALUES (2, N'40206242', N'Mabel')
SET IDENTITY_INSERT [dbo].[trabajador] OFF
GO
SET IDENTITY_INSERT [dbo].[correlativo] ON 

INSERT [dbo].[correlativo] ([IdCorrelativo], [codigo], [idTrabajador], [IdTipDoc], [descripcion], [monto]) VALUES (1, N'0001', 3, 1, N'dasdada', 102)
INSERT [dbo].[correlativo] ([IdCorrelativo], [codigo], [idTrabajador], [IdTipDoc], [descripcion], [monto]) VALUES (2, N'0002', 4, 1, N'dasds', 1010)
INSERT [dbo].[correlativo] ([IdCorrelativo], [codigo], [idTrabajador], [IdTipDoc], [descripcion], [monto]) VALUES (3, N'0003', 5, 1, N'kjhkjh', 102)
INSERT [dbo].[correlativo] ([IdCorrelativo], [codigo], [idTrabajador], [IdTipDoc], [descripcion], [monto]) VALUES (4, N'0004', 5, 1, N'hjkjh', 45)
SET IDENTITY_INSERT [dbo].[correlativo] OFF
GO
