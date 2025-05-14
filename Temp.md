# 


## database
``` bash
docker run --name sisypos -e MYSQL_ROOT_PASSWORD=rootpassword -d -p 3306:3306 mysql:latest
```






CREATE DATABASE SisyphusDB;
USE SisyphusDB;

<!--  -->
```sql
CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE RestaurantTable (
    TableID INT AUTO_INCREMENT PRIMARY KEY,  -- 테이블 고유 ID
    TableName VARCHAR(50) NOT NULL,  -- 테이블 이름
    TotalAmount DECIMAL(10, 2) DEFAULT 0,  -- 테이블에서 주문된 총액
    Status ENUM('Available', 'Occupied', 'Empty') NOT NULL DEFAULT 'Empty'  -- 테이블 상태
);
CREATE TABLE Item (
    ItemID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Quantity INT DEFAULT 1,
    Price DECIMAL(10, 2) NOT NULL,
    ImageUrl VARCHAR(255)
);
CREATE TABLE OrderDetail (
    OrderDetailID INT AUTO_INCREMENT PRIMARY KEY,  -- 주문 상세 고유 ID
    TableID INT NOT NULL,  -- 주문이 발생한 테이블 ID
    ItemID INT NOT NULL,  -- 주문된 상품 ID
    Quantity INT NOT NULL DEFAULT 1,  -- 주문 수량
    Price DECIMAL(10, 2) NOT NULL,  -- 주문 당시 가격 (상품 가격과 독립적일 수 있음)
    OrderTime DATETIME DEFAULT CURRENT_TIMESTAMP,  -- 주문 시간

    -- 외래 키 설정
    FOREIGN KEY (TableID) REFERENCES RestaurantTable(TableID)
        ON DELETE CASCADE,
    FOREIGN KEY (ItemID) REFERENCES Item(ItemID)
        ON DELETE CASCADE
);
```
```SQL
SELECT 
    i.Name AS ItemName, 
    od.Quantity, 
    od.Price, 
    (od.Quantity * od.Price) AS TotalPrice, 
    od.OrderTime
FROM 
    OrderDetail od
JOIN 
    Item i ON od.ItemID = i.ItemID
WHERE 
    od.TableID = 1;  -- 테이블 번호 1번에 포함된 아이템 조회

```
```sql
SELECT 
    od.OrderDetailID,
    rt.TableID,
    rt.TableName,
    i.ItemID,
    i.Name AS ItemName,
    od.Quantity,
    od.Price,
    od.OrderTime
FROM 
    OrderDetail od
JOIN 
    RestaurantTable rt ON od.TableID = rt.TableID
JOIN 
    Item i ON od.ItemID = i.ItemID
WHERE 
    od.TableID = 1
ORDER BY 
    od.OrderTime;

```


<!-- Insert Data -->
```sql
INSERT INTO RestaurantTable (TableName, TotalAmount, Status) VALUES
('Table 1', 0.00, 'Empty'),
('Table 2', 0.00, 'Empty'),
('Table 3', 0.00, 'Empty'),
('Table 4', 0.00, 'Empty'),
('Table 5', 0.00, 'Empty'),
('Table 6', 0.00, 'Empty'),
('Table 7', 0.00, 'Empty'),
('Table 8', 0.00, 'Empty'),
('Table 9', 0.00, 'Empty'),
('Table 10', 0.00, 'Empty'),
('Table 11', 0.00, 'Empty'),
('Table 12', 0.00, 'Empty'),
('Table 13', 0.00, 'Empty'),
('Table 14', 0.00, 'Empty'),
('Table 15', 0.00, 'Empty'),
('Table 16', 0.00, 'Empty'),
('Table 17', 0.00, 'Empty');
```
```sql
INSERT INTO Item (Name, Quantity, Price, ImageUrl) VALUES
('food1', 10, 1000, 'https://foodish-api.com/images/dessert/dessert1.jpg'),
('food2', 10, 2000, 'https://foodish-api.com/images/dessert/dessert2.jpg'),
('food3', 10, 3000, 'https://foodish-api.com/images/dessert/dessert3.jpg'),
('food4', 10, 4000, 'https://foodish-api.com/images/dessert/dessert4.jpg'),
('food5', 10, 5000, 'https://foodish-api.com/images/dessert/dessert5.jpg'),
('food6', 10, 6000, 'https://foodish-api.com/images/dessert/dessert6.jpg'),
('food7', 10, 7000, 'https://foodish-api.com/images/dessert/dessert7.jpg'),
('food8', 10, 8000, 'https://foodish-api.com/images/dessert/dessert8.jpg'),
('food9', 10, 9000, 'https://foodish-api.com/images/dessert/dessert9.jpg'),
('food10', 10, 10000, 'https://foodish-api.com/images/dessert/dessert10.jpg');
```



```sql



CREATE TABLE Receipt (
    ReceiptID INT AUTO_INCREMENT PRIMARY KEY,  -- 영수증 고유 ID
    TableID INT,  -- 주문한 테이블의 ID
    Date DATETIME DEFAULT CURRENT_TIMESTAMP,  -- 영수증 발행 날짜
    TotalAmount DECIMAL(10, 2) NOT NULL,  -- 영수증의 총 금액
    FOREIGN KEY (TableID) REFERENCES RestaurantTable(TableID)  -- 테이블과의 관계
);


SHOW TABLES;
select * from Users;

INSERT INTO RestaurantTable (TableName, TotalAmount, Status) VALUES
('Table 1', 0.00, 'Empty'),
('Table 2', 0.00, 'Empty'),
('Table 3', 0.00, 'Empty'),
('Table 4', 0.00, 'Empty'),
('Table 5', 0.00, 'Empty'),
('Table 6', 0.00, 'Empty'),
('Table 7', 0.00, 'Empty'),
('Table 8', 0.00, 'Empty'),
('Table 9', 0.00, 'Empty'),
('Table 10', 0.00, 'Empty'),
('Table 11', 0.00, 'Empty'),
('Table 12', 0.00, 'Empty'),
('Table 13', 0.00, 'Empty'),
('Table 14', 0.00, 'Empty'),
('Table 15', 0.00, 'Empty'),
('Table 16', 0.00, 'Empty'),
('Table 17', 0.00, 'Empty');


select * from RestaurantTable;

INSERT INTO Item (TableID, Name, Quantity, Price, ImageUrl, TotalPrice) VALUES
(1, 'Cheeseburger', 2, 5.99, 'https://foodish-api.com/images/dessert/dessert1.jpg', 11.98),
(1, 'French Fries', 1, 2.99, 'https://example.com/images/fries.png', 2.99),
(2, 'Coke', 3, 1.50, 'https://example.com/images/coke.png', 4.50),
(2, 'Chicken Nuggets', 1, 4.99, 'https://example.com/images/nuggets.png', 4.99),
(3, 'Pizza', 1, 9.99, 'https://example.com/images/pizza.png', 9.99),
(3, 'Sprite', 2, 1.50, 'https://example.com/images/sprite.png', 3.00),
(4, 'Spaghetti', 1, 8.50, 'https://example.com/images/spaghetti.png', 8.50),
(5, 'Garlic Bread', 2, 2.50, 'https://example.com/images/garlicbread.png', 5.00),
(6, 'Salad', 1, 3.99, 'https://example.com/images/salad.png', 3.99),
(7, 'Iced Tea', 2, 2.00, 'https://example.com/images/icedtea.png', 4.00);


select * from Item;



drop table Item;