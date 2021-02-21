db.users.insertOne({
    _id: 3,
    "name": "James",
    "email": "test@mail.tu",
	
    "age": 35,
    "HasCar": false,
    "favColor": ["Red", "Green", "Blue"],
})

db.users.insertMany([
{_id: 4,
    "name": "Smith",
    "email": "test@mail.tu",
    "age": 55,
"HasCar": false
},
{_id: 5,
    "name": "Adam",
    "email": "test@mail.tu",
    "age": 45,
"HasCar": false
}
])

