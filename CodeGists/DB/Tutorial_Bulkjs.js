db.users.bulkWrite([{
            updateMany: {
                "filter": {
                    name: "Mike"
                },
                update: {
                    $set: {
                        email: "new_email@.ru"
                    }
                }
            }
        }

    ])



db.users.updateOne({name:"Mike"},{$set:{age:15}})

db.users.updateOne({age:45},{$set:{age:15}})