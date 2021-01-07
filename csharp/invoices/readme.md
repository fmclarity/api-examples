This project provides a basic example of how you could use the standard HTTP client to get Work Orders and Invoices attached.

# Getting started

- Ensure you have .net 5.0 installed
- Update the `Email` and `Password` properties in `GraphqlQueries` with the values provided
- Now you can run `dotnet run` from the command line in the `invoices` directory
- Don't forget to update the `completionDate` `from` and `to` values accordingly
- The output should look something like:

```
{
    "_id": "WDgs9ar3mLq6sdWuq",
    "name": "test work order",
    "issuedAt": "2021-01-07T01:21:09.911Z",
    "completionDate": "2021-01-07T01:21:37.562Z",
    "isInternal": true,
    "facility": {
        "name": "AKR",
        "address": "32 Dotterel Street, Hinchinbrook"
    },
    "costCentreCode": "",
    "costThreshold": "50",
    "invoiceVerified": false,
    "invoiceVerifiedBy": null,
    "invoiceStatus": "Approved",
    "invoiceDetails": {
        "invoiceNumber": "MM001",
        "status": "Approved",
        "dueDate": "2021-01-14T01:21:13.952Z",
        "invoiceDate": "2021-01-07T01:21:13.952Z",
        "details": "test work order",
        "totalPayable": 50,
        "gst": 5,
        "totalPayablePlusGst": 55,
        "invoice": [
            {
                "name": "asd.txt"
            }
        ]
    },
    "supplier": {
        "name": "Mounties Maintenance",
        "email": "darren.wren@mountiesgroup.com.au",
        "phone": null,
        "phone2": null,
        "address": {
            "streetName": null,
            "state": null
        }
    },
    "supplierContacts": [],
    "service": {
        "name": "Access Control"
    },
    "subservice": null,
    "approvedBy": null
}
]
```