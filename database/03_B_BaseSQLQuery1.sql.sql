select * from Regions

--Provincias x Regiones
select P.Id [IdProvince], P.Name [CityName], R.Name [NameRegion] from Regions R
inner join Provinces P on P.RegionId=R.Id and R.Id = '1'

--Ciudades x Provincias
select P.Id [IdProvince], P.Name [CityName], C.Name [CityName] from Cities C
inner join Provinces P on P.Id=C.ProvinceId and P.Id = '1'