/**
 * NamSor API v2
 * NamSor API v2 : enpoints to process personal names (gender, cultural origin or ethnicity) in all alphabets or languages. By default, enpoints use 1 unit per name (ex. Gender), but Ethnicity classification uses 10 to 20 units per name depending on taxonomy. Use GET methods for small tests, but prefer POST methods for higher throughput (batch processing of up to 100 names at a time). Need something you can\'t find here? We have many more features coming soon. Let us know, we\'ll do our best to add it! 
 *
 * The version of the OpenAPI document: 2.0.29
 * Contact: contact@namsor.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { RequestFile } from './models';
import { PersonalNameIn } from './personalNameIn';

export class BatchPersonalNameIn {
    'personalNames'?: Array<PersonalNameIn>;

    static discriminator: string | undefined = undefined;

    static attributeTypeMap: Array<{name: string, baseName: string, type: string}> = [
        {
            "name": "personalNames",
            "baseName": "personalNames",
            "type": "Array<PersonalNameIn>"
        }    ];

    static getAttributeTypeMap() {
        return BatchPersonalNameIn.attributeTypeMap;
    }
}

