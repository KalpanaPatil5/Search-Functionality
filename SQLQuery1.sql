create database Assignment;
use Assignment;

create table Product(
	Product_ID int primary key identity (1,1),
	Product_Name varchar(100),
	Size varchar(5),
	Price int,
	Manufacture_date date,
	Category varchar(50)
)

insert into product (Product_Name,Size,Price,Manufacture_date,Category) values ('Laptop', 'NA', 35000, '10-05-2022', 'Electronics'),
('Apple iPhone', 'Max', 99000, '01-07-2023', 'Electronics'), ('Dress', 'M', 1000, '03-21-2023', 'Fashion'), ('Shoes', '8', 3999, '09-30-2022', 'Fashion'),
('Bags', 'NA', 500, '02-05-2023', 'Fashion');

select * from product;

/*stored procedure for inserting new record*/
create proc InsertProduct(
	@Product_Name varchar(100),
	@Size varchar(5),
	@Price int,
	@Manufacture_date date,
	@Category varchar(50)
)
as
begin
	insert into product (Product_Name,Size,Price,Manufacture_date,Category) values (@Product_Name, @Size, @Price, @Manufacture_date, @Category)
end

exec InsertProduct 'Samrt TV', 'NA', 15000, '12-31-2020', 'Electronics';

/*stored procedure for seraching products*/
create proc SearchProducts(
	@Product_Name varchar(100),
	@Size varchar(5),
	@Price int,
	@Manufacture_date date,
	@Category varchar(50),
	@Conjunction varchar(3)
)
as
begin
	select * from product where (@Product_Name is null or Product_Name = @Product_Name)
							AND (@Size is null or Size = @Size)
							AND (@Price is null or Price = @Price)
							AND (@Manufacture_date is null or Manufacture_date = @Manufacture_date)
							AND (@Category is null or Category = @Category)
end

exec SearchProducts @Product_Name = null, @Size = null, @Price = null, @Manufacture_date = null, @Category = null, @Conjunction = null;