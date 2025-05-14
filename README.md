# Sisyphus 프로젝트

## 프로젝트 소개
Sisyphus는 레스토랑 테이블 관리 및 주문 시스템을 구현한 데스크톱 애플리케이션입니다.  
사용자는 테이블 상태를 확인하고, 주문을 추가하거나 결제를 처리할 수 있습니다.  
직관적인 UI와 데이터베이스 연동을 통해 효율적인 레스토랑 운영을 지원합니다.

## 프로젝트 기간
2025년 5월 12일 ~ 2025년 5월 16일

## 주요 기능
- **로그인 및 회원가입**: 사용자 인증 및 계정 관리.
- **테이블 관리**: 테이블 상태 확인 및 상세 정보 표시.
- **주문 관리**: 상품 선택 및 주문 추가.
- **결제 처리**: 주문 내역 삭제 및 테이블 상태 초기화.
- **데이터베이스 연동**: MySQL을 사용한 데이터 저장 및 조회.

## 기술 스택
- **프로그래밍 언어**: C#
- **프레임워크**: .NET Framework 4.7.2
- **데이터베이스**: MySQL

## 화면 구성
![alt text](<loginPage.png>)
![alt text](<TableListPage.png>)
![alt text](<ItemSelectPage.png>)

## 폴더구조
```md
Sisyphus/
├── Forms
│   ├── LoginForm.cs
│   ├── MainForm.cs
│   ├── ProductListForm.cs
│   └── ReceiptForm.cs
├── Models
│   ├── Item.cs
│   └── RestaurantTable.cs
├── Services
│     ├── AuthService.cs
│     ├── ItemService.cs
│     └── RestaurantTableService.cs
└─ Utils
    └── Constants.cs
```

## 데이터베이스 구조
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