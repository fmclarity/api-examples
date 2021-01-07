using System;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace api_examples
{
    public static class GraphqlQueries
    {
        private const string Email = "Email Value Provided";
        private const string Password = "Password Provided";

        public static string GetTokenMutation = @"
        mutation loginWithPassword {
            loginWithPassword(email: """ + Email + @""", plainPassword: """ + Password + @""" ) {
                token
            }
        }";

        public static string GetWorkOrdersQuery = @"
        query requests {
            requests(
                # Possible args
                status: Complete # Enum, One of RequestStatus, Default is Open
            invoiceStatusLookup: [Approved, Issued]
                completionDate: {
                    from: ""2020-08-04T14:20:10.108Z"",
                    to: ""2021-01-30T14:20:10.108Z""
                }
            ) {
                _id
            name
            issuedAt
            completionDate
            isInternal
            facility {
            name
            address
            }
                costCentreCode
            costThreshold
            invoiceVerified
            invoiceVerifiedBy {
            name
            email
            role
            }
            invoiceStatus
            invoiceDetails {
                invoiceNumber
            status
            dueDate
            invoiceDate
            details
            totalPayable
            gst
            totalPayablePlusGst
            invoice {
                name #invoice file name
            }
            }
            supplier {
            name
            email
            phone
            phone2
            address {
                streetName
                state
            }
            }
            supplierContacts {
            name
            email
            role
            team {
                phone
                phone2
                address {
                streetName
                state
                }
            }
            }
            service {
            name
            }
            subservice {
            name
            }
            approvedBy {
            name
            email
            }
                # Use request type fields
            }
        }
        ";
    }
}