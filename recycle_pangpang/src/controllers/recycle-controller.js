const HttpStatus = require('http-status');
const RecycleService = require('../services/recycle-service');

// 아이템 목록 전체 조회
exports.findAllItems = async (req, res, next) => {

    const items = await RecycleService.findAllItems();

    res.status(HttpStatus.OK).send({
        status: HttpStatus.OK,
        message: 'OK',
        results: items
    });
}


/*

1. 물품 전체 조회
[
    {
        "id": 1,
        "name": "아이템1",
        "price": 1000,
        "description": "아이템1 설명",
        "category": "아이템1 카테고리"
        "분해 가능 여부" : t/f
    }
]

2. 분해 가능 물품만 조회
[
    {
        "id": 1,
        "name": "아이템1",
        "price": 1000,
        "description": "아이템1 설명",
        "category": "아이템1 카테고리"
        "분해 가능 여부" : t
    }
]

3. 물품과 재료 관계 테이블 조회  ==> for 문
select 물품과 재료 관계 테이블 where item_no = 1
[
    "item_no": 1,
    "material_no": 1,
]

4. 재료 테이블 조회  ==> for 문
select 재료 테이블 where material_no = 1
*/