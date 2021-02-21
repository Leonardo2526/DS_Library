use DS_DB

db.users.find({},{_id:0})
db.users.find({},{_id:0}).sort({age:1})
try{db.users.find({age:0},{_id:0});}catch(e){print(e);}
db.users.find({child:{$exists:true}},{_id:0})
db.users.updateOne({age:35},{$set:{age:15}})
db.users.updateMany({age:35},{$set:{age:15}})
db.users.replaceOne({age:15},{name:"New_user",Hascar:false},)



db.users.createIndex({email: "text", name: "text"})
db.users.find({$text: {$search: "New_email@.ru"}})

db.users.find(
{$text: {$search: "Mike 15"}},
	{score: {$meta: "textScore"}}
).sort({score: {$meta: "textScore"}})


db.users.count({age: 45})
db.users.distinct("email")

db.users.aggregate([
{$match: {name: "Mike"}},
	{$group: {_id: "$name", age: {$sum: "$age"}}}
])