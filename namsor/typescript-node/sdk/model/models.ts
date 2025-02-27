import localVarRequest from 'request';

export * from './aPIBillingPeriodUsageOut';
export * from './aPIClassifierOut';
export * from './aPIClassifierTaxonomyOut';
export * from './aPIClassifiersStatusOut';
export * from './aPICounterV2Out';
export * from './aPIKeyOut';
export * from './aPIPeriodUsageOut';
export * from './aPIPlanSubscriptionOut';
export * from './aPIServiceOut';
export * from './aPIServicesOut';
export * from './aPIUsageAggregatedOut';
export * from './aPIUsageHistoryOut';
export * from './batchCommunityEngageFullOut';
export * from './batchCommunityEngageOut';
export * from './batchCorridorIn';
export * from './batchCorridorOut';
export * from './batchFirstLastNameCasteOut';
export * from './batchFirstLastNameCastegroupOut';
export * from './batchFirstLastNameDiasporaedOut';
export * from './batchFirstLastNameGenderIn';
export * from './batchFirstLastNameGenderedOut';
export * from './batchFirstLastNameGeoIn';
export * from './batchFirstLastNameGeoOut';
export * from './batchFirstLastNameGeoSubclassificationOut';
export * from './batchFirstLastNameGeoSubdivisionIn';
export * from './batchFirstLastNameGeoZippedIn';
export * from './batchFirstLastNameIn';
export * from './batchFirstLastNameOriginedOut';
export * from './batchFirstLastNamePhoneCodedOut';
export * from './batchFirstLastNamePhoneNumberGeoIn';
export * from './batchFirstLastNamePhoneNumberIn';
export * from './batchFirstLastNameReligionedOut';
export * from './batchFirstLastNameSubdivisionIn';
export * from './batchFirstLastNameUSRaceEthnicityOut';
export * from './batchMatchPersonalFirstLastNameIn';
export * from './batchNameGeoIn';
export * from './batchNameIn';
export * from './batchNameMatchCandidatesOut';
export * from './batchNameMatchedOut';
export * from './batchPersonalNameCastegroupOut';
export * from './batchPersonalNameDiasporaedOut';
export * from './batchPersonalNameGenderedOut';
export * from './batchPersonalNameGeoIn';
export * from './batchPersonalNameGeoOut';
export * from './batchPersonalNameGeoSubclassificationOut';
export * from './batchPersonalNameGeoSubdivisionIn';
export * from './batchPersonalNameIn';
export * from './batchPersonalNameOriginedOut';
export * from './batchPersonalNameParsedOut';
export * from './batchPersonalNameReligionedOut';
export * from './batchPersonalNameSubdivisionIn';
export * from './batchPersonalNameUSRaceEthnicityOut';
export * from './batchProperNounCategorizedOut';
export * from './communityEngageOptionOut';
export * from './communityEngageOut';
export * from './corridorIn';
export * from './corridorOut';
export * from './feedbackLoopOut';
export * from './firstLastNameCasteOut';
export * from './firstLastNameCastegroupOut';
export * from './firstLastNameDiasporaedOut';
export * from './firstLastNameGenderIn';
export * from './firstLastNameGenderedOut';
export * from './firstLastNameGeoIn';
export * from './firstLastNameGeoOut';
export * from './firstLastNameGeoSubclassificationOut';
export * from './firstLastNameGeoSubdivisionIn';
export * from './firstLastNameGeoZippedIn';
export * from './firstLastNameIn';
export * from './firstLastNameOriginedOut';
export * from './firstLastNameOut';
export * from './firstLastNamePhoneCodedOut';
export * from './firstLastNamePhoneNumberGeoIn';
export * from './firstLastNamePhoneNumberIn';
export * from './firstLastNameReligionedOut';
export * from './firstLastNameSubdivisionIn';
export * from './firstLastNameUSRaceEthnicityOut';
export * from './matchPersonalFirstLastNameIn';
export * from './nameGeoIn';
export * from './nameIn';
export * from './nameMatchCandidateOut';
export * from './nameMatchCandidatesOut';
export * from './nameMatchedOut';
export * from './personalNameCastegroupOut';
export * from './personalNameDiasporaedOut';
export * from './personalNameGenderedOut';
export * from './personalNameGeoIn';
export * from './personalNameGeoOut';
export * from './personalNameGeoSubclassificationOut';
export * from './personalNameGeoSubdivisionIn';
export * from './personalNameIn';
export * from './personalNameOriginedOut';
export * from './personalNameParsedOut';
export * from './personalNameReligionedOut';
export * from './personalNameSubdivisionIn';
export * from './personalNameUSRaceEthnicityOut';
export * from './properNounCategorizedOut';
export * from './regionISO';
export * from './regionOut';
export * from './religionStatOut';
export * from './softwareVersionOut';

import * as fs from 'fs';

export interface RequestDetailedFile {
    value: Buffer;
    options?: {
        filename?: string;
        contentType?: string;
    }
}

export type RequestFile = string | Buffer | fs.ReadStream | RequestDetailedFile;


import { APIBillingPeriodUsageOut } from './aPIBillingPeriodUsageOut';
import { APIClassifierOut } from './aPIClassifierOut';
import { APIClassifierTaxonomyOut } from './aPIClassifierTaxonomyOut';
import { APIClassifiersStatusOut } from './aPIClassifiersStatusOut';
import { APICounterV2Out } from './aPICounterV2Out';
import { APIKeyOut } from './aPIKeyOut';
import { APIPeriodUsageOut } from './aPIPeriodUsageOut';
import { APIPlanSubscriptionOut } from './aPIPlanSubscriptionOut';
import { APIServiceOut } from './aPIServiceOut';
import { APIServicesOut } from './aPIServicesOut';
import { APIUsageAggregatedOut } from './aPIUsageAggregatedOut';
import { APIUsageHistoryOut } from './aPIUsageHistoryOut';
import { BatchCommunityEngageFullOut } from './batchCommunityEngageFullOut';
import { BatchCommunityEngageOut } from './batchCommunityEngageOut';
import { BatchCorridorIn } from './batchCorridorIn';
import { BatchCorridorOut } from './batchCorridorOut';
import { BatchFirstLastNameCasteOut } from './batchFirstLastNameCasteOut';
import { BatchFirstLastNameCastegroupOut } from './batchFirstLastNameCastegroupOut';
import { BatchFirstLastNameDiasporaedOut } from './batchFirstLastNameDiasporaedOut';
import { BatchFirstLastNameGenderIn } from './batchFirstLastNameGenderIn';
import { BatchFirstLastNameGenderedOut } from './batchFirstLastNameGenderedOut';
import { BatchFirstLastNameGeoIn } from './batchFirstLastNameGeoIn';
import { BatchFirstLastNameGeoOut } from './batchFirstLastNameGeoOut';
import { BatchFirstLastNameGeoSubclassificationOut } from './batchFirstLastNameGeoSubclassificationOut';
import { BatchFirstLastNameGeoSubdivisionIn } from './batchFirstLastNameGeoSubdivisionIn';
import { BatchFirstLastNameGeoZippedIn } from './batchFirstLastNameGeoZippedIn';
import { BatchFirstLastNameIn } from './batchFirstLastNameIn';
import { BatchFirstLastNameOriginedOut } from './batchFirstLastNameOriginedOut';
import { BatchFirstLastNamePhoneCodedOut } from './batchFirstLastNamePhoneCodedOut';
import { BatchFirstLastNamePhoneNumberGeoIn } from './batchFirstLastNamePhoneNumberGeoIn';
import { BatchFirstLastNamePhoneNumberIn } from './batchFirstLastNamePhoneNumberIn';
import { BatchFirstLastNameReligionedOut } from './batchFirstLastNameReligionedOut';
import { BatchFirstLastNameSubdivisionIn } from './batchFirstLastNameSubdivisionIn';
import { BatchFirstLastNameUSRaceEthnicityOut } from './batchFirstLastNameUSRaceEthnicityOut';
import { BatchMatchPersonalFirstLastNameIn } from './batchMatchPersonalFirstLastNameIn';
import { BatchNameGeoIn } from './batchNameGeoIn';
import { BatchNameIn } from './batchNameIn';
import { BatchNameMatchCandidatesOut } from './batchNameMatchCandidatesOut';
import { BatchNameMatchedOut } from './batchNameMatchedOut';
import { BatchPersonalNameCastegroupOut } from './batchPersonalNameCastegroupOut';
import { BatchPersonalNameDiasporaedOut } from './batchPersonalNameDiasporaedOut';
import { BatchPersonalNameGenderedOut } from './batchPersonalNameGenderedOut';
import { BatchPersonalNameGeoIn } from './batchPersonalNameGeoIn';
import { BatchPersonalNameGeoOut } from './batchPersonalNameGeoOut';
import { BatchPersonalNameGeoSubclassificationOut } from './batchPersonalNameGeoSubclassificationOut';
import { BatchPersonalNameGeoSubdivisionIn } from './batchPersonalNameGeoSubdivisionIn';
import { BatchPersonalNameIn } from './batchPersonalNameIn';
import { BatchPersonalNameOriginedOut } from './batchPersonalNameOriginedOut';
import { BatchPersonalNameParsedOut } from './batchPersonalNameParsedOut';
import { BatchPersonalNameReligionedOut } from './batchPersonalNameReligionedOut';
import { BatchPersonalNameSubdivisionIn } from './batchPersonalNameSubdivisionIn';
import { BatchPersonalNameUSRaceEthnicityOut } from './batchPersonalNameUSRaceEthnicityOut';
import { BatchProperNounCategorizedOut } from './batchProperNounCategorizedOut';
import { CommunityEngageOptionOut } from './communityEngageOptionOut';
import { CommunityEngageOut } from './communityEngageOut';
import { CorridorIn } from './corridorIn';
import { CorridorOut } from './corridorOut';
import { FeedbackLoopOut } from './feedbackLoopOut';
import { FirstLastNameCasteOut } from './firstLastNameCasteOut';
import { FirstLastNameCastegroupOut } from './firstLastNameCastegroupOut';
import { FirstLastNameDiasporaedOut } from './firstLastNameDiasporaedOut';
import { FirstLastNameGenderIn } from './firstLastNameGenderIn';
import { FirstLastNameGenderedOut } from './firstLastNameGenderedOut';
import { FirstLastNameGeoIn } from './firstLastNameGeoIn';
import { FirstLastNameGeoOut } from './firstLastNameGeoOut';
import { FirstLastNameGeoSubclassificationOut } from './firstLastNameGeoSubclassificationOut';
import { FirstLastNameGeoSubdivisionIn } from './firstLastNameGeoSubdivisionIn';
import { FirstLastNameGeoZippedIn } from './firstLastNameGeoZippedIn';
import { FirstLastNameIn } from './firstLastNameIn';
import { FirstLastNameOriginedOut } from './firstLastNameOriginedOut';
import { FirstLastNameOut } from './firstLastNameOut';
import { FirstLastNamePhoneCodedOut } from './firstLastNamePhoneCodedOut';
import { FirstLastNamePhoneNumberGeoIn } from './firstLastNamePhoneNumberGeoIn';
import { FirstLastNamePhoneNumberIn } from './firstLastNamePhoneNumberIn';
import { FirstLastNameReligionedOut } from './firstLastNameReligionedOut';
import { FirstLastNameSubdivisionIn } from './firstLastNameSubdivisionIn';
import { FirstLastNameUSRaceEthnicityOut } from './firstLastNameUSRaceEthnicityOut';
import { MatchPersonalFirstLastNameIn } from './matchPersonalFirstLastNameIn';
import { NameGeoIn } from './nameGeoIn';
import { NameIn } from './nameIn';
import { NameMatchCandidateOut } from './nameMatchCandidateOut';
import { NameMatchCandidatesOut } from './nameMatchCandidatesOut';
import { NameMatchedOut } from './nameMatchedOut';
import { PersonalNameCastegroupOut } from './personalNameCastegroupOut';
import { PersonalNameDiasporaedOut } from './personalNameDiasporaedOut';
import { PersonalNameGenderedOut } from './personalNameGenderedOut';
import { PersonalNameGeoIn } from './personalNameGeoIn';
import { PersonalNameGeoOut } from './personalNameGeoOut';
import { PersonalNameGeoSubclassificationOut } from './personalNameGeoSubclassificationOut';
import { PersonalNameGeoSubdivisionIn } from './personalNameGeoSubdivisionIn';
import { PersonalNameIn } from './personalNameIn';
import { PersonalNameOriginedOut } from './personalNameOriginedOut';
import { PersonalNameParsedOut } from './personalNameParsedOut';
import { PersonalNameReligionedOut } from './personalNameReligionedOut';
import { PersonalNameSubdivisionIn } from './personalNameSubdivisionIn';
import { PersonalNameUSRaceEthnicityOut } from './personalNameUSRaceEthnicityOut';
import { ProperNounCategorizedOut } from './properNounCategorizedOut';
import { RegionISO } from './regionISO';
import { RegionOut } from './regionOut';
import { ReligionStatOut } from './religionStatOut';
import { SoftwareVersionOut } from './softwareVersionOut';

/* tslint:disable:no-unused-variable */
let primitives = [
                    "string",
                    "boolean",
                    "double",
                    "integer",
                    "long",
                    "float",
                    "number",
                    "any"
                 ];

let enumsMap: {[index: string]: any} = {
        "FirstLastNameGenderedOut.LikelyGenderEnum": FirstLastNameGenderedOut.LikelyGenderEnum,
        "FirstLastNameUSRaceEthnicityOut.RaceEthnicityAltEnum": FirstLastNameUSRaceEthnicityOut.RaceEthnicityAltEnum,
        "FirstLastNameUSRaceEthnicityOut.RaceEthnicityEnum": FirstLastNameUSRaceEthnicityOut.RaceEthnicityEnum,
        "NameMatchedOut.MatchStatusEnum": NameMatchedOut.MatchStatusEnum,
        "PersonalNameGenderedOut.LikelyGenderEnum": PersonalNameGenderedOut.LikelyGenderEnum,
        "PersonalNameParsedOut.NameParserTypeEnum": PersonalNameParsedOut.NameParserTypeEnum,
        "PersonalNameParsedOut.NameParserTypeAltEnum": PersonalNameParsedOut.NameParserTypeAltEnum,
        "PersonalNameUSRaceEthnicityOut.RaceEthnicityAltEnum": PersonalNameUSRaceEthnicityOut.RaceEthnicityAltEnum,
        "PersonalNameUSRaceEthnicityOut.RaceEthnicityEnum": PersonalNameUSRaceEthnicityOut.RaceEthnicityEnum,
}

let typeMap: {[index: string]: any} = {
    "APIBillingPeriodUsageOut": APIBillingPeriodUsageOut,
    "APIClassifierOut": APIClassifierOut,
    "APIClassifierTaxonomyOut": APIClassifierTaxonomyOut,
    "APIClassifiersStatusOut": APIClassifiersStatusOut,
    "APICounterV2Out": APICounterV2Out,
    "APIKeyOut": APIKeyOut,
    "APIPeriodUsageOut": APIPeriodUsageOut,
    "APIPlanSubscriptionOut": APIPlanSubscriptionOut,
    "APIServiceOut": APIServiceOut,
    "APIServicesOut": APIServicesOut,
    "APIUsageAggregatedOut": APIUsageAggregatedOut,
    "APIUsageHistoryOut": APIUsageHistoryOut,
    "BatchCommunityEngageFullOut": BatchCommunityEngageFullOut,
    "BatchCommunityEngageOut": BatchCommunityEngageOut,
    "BatchCorridorIn": BatchCorridorIn,
    "BatchCorridorOut": BatchCorridorOut,
    "BatchFirstLastNameCasteOut": BatchFirstLastNameCasteOut,
    "BatchFirstLastNameCastegroupOut": BatchFirstLastNameCastegroupOut,
    "BatchFirstLastNameDiasporaedOut": BatchFirstLastNameDiasporaedOut,
    "BatchFirstLastNameGenderIn": BatchFirstLastNameGenderIn,
    "BatchFirstLastNameGenderedOut": BatchFirstLastNameGenderedOut,
    "BatchFirstLastNameGeoIn": BatchFirstLastNameGeoIn,
    "BatchFirstLastNameGeoOut": BatchFirstLastNameGeoOut,
    "BatchFirstLastNameGeoSubclassificationOut": BatchFirstLastNameGeoSubclassificationOut,
    "BatchFirstLastNameGeoSubdivisionIn": BatchFirstLastNameGeoSubdivisionIn,
    "BatchFirstLastNameGeoZippedIn": BatchFirstLastNameGeoZippedIn,
    "BatchFirstLastNameIn": BatchFirstLastNameIn,
    "BatchFirstLastNameOriginedOut": BatchFirstLastNameOriginedOut,
    "BatchFirstLastNamePhoneCodedOut": BatchFirstLastNamePhoneCodedOut,
    "BatchFirstLastNamePhoneNumberGeoIn": BatchFirstLastNamePhoneNumberGeoIn,
    "BatchFirstLastNamePhoneNumberIn": BatchFirstLastNamePhoneNumberIn,
    "BatchFirstLastNameReligionedOut": BatchFirstLastNameReligionedOut,
    "BatchFirstLastNameSubdivisionIn": BatchFirstLastNameSubdivisionIn,
    "BatchFirstLastNameUSRaceEthnicityOut": BatchFirstLastNameUSRaceEthnicityOut,
    "BatchMatchPersonalFirstLastNameIn": BatchMatchPersonalFirstLastNameIn,
    "BatchNameGeoIn": BatchNameGeoIn,
    "BatchNameIn": BatchNameIn,
    "BatchNameMatchCandidatesOut": BatchNameMatchCandidatesOut,
    "BatchNameMatchedOut": BatchNameMatchedOut,
    "BatchPersonalNameCastegroupOut": BatchPersonalNameCastegroupOut,
    "BatchPersonalNameDiasporaedOut": BatchPersonalNameDiasporaedOut,
    "BatchPersonalNameGenderedOut": BatchPersonalNameGenderedOut,
    "BatchPersonalNameGeoIn": BatchPersonalNameGeoIn,
    "BatchPersonalNameGeoOut": BatchPersonalNameGeoOut,
    "BatchPersonalNameGeoSubclassificationOut": BatchPersonalNameGeoSubclassificationOut,
    "BatchPersonalNameGeoSubdivisionIn": BatchPersonalNameGeoSubdivisionIn,
    "BatchPersonalNameIn": BatchPersonalNameIn,
    "BatchPersonalNameOriginedOut": BatchPersonalNameOriginedOut,
    "BatchPersonalNameParsedOut": BatchPersonalNameParsedOut,
    "BatchPersonalNameReligionedOut": BatchPersonalNameReligionedOut,
    "BatchPersonalNameSubdivisionIn": BatchPersonalNameSubdivisionIn,
    "BatchPersonalNameUSRaceEthnicityOut": BatchPersonalNameUSRaceEthnicityOut,
    "BatchProperNounCategorizedOut": BatchProperNounCategorizedOut,
    "CommunityEngageOptionOut": CommunityEngageOptionOut,
    "CommunityEngageOut": CommunityEngageOut,
    "CorridorIn": CorridorIn,
    "CorridorOut": CorridorOut,
    "FeedbackLoopOut": FeedbackLoopOut,
    "FirstLastNameCasteOut": FirstLastNameCasteOut,
    "FirstLastNameCastegroupOut": FirstLastNameCastegroupOut,
    "FirstLastNameDiasporaedOut": FirstLastNameDiasporaedOut,
    "FirstLastNameGenderIn": FirstLastNameGenderIn,
    "FirstLastNameGenderedOut": FirstLastNameGenderedOut,
    "FirstLastNameGeoIn": FirstLastNameGeoIn,
    "FirstLastNameGeoOut": FirstLastNameGeoOut,
    "FirstLastNameGeoSubclassificationOut": FirstLastNameGeoSubclassificationOut,
    "FirstLastNameGeoSubdivisionIn": FirstLastNameGeoSubdivisionIn,
    "FirstLastNameGeoZippedIn": FirstLastNameGeoZippedIn,
    "FirstLastNameIn": FirstLastNameIn,
    "FirstLastNameOriginedOut": FirstLastNameOriginedOut,
    "FirstLastNameOut": FirstLastNameOut,
    "FirstLastNamePhoneCodedOut": FirstLastNamePhoneCodedOut,
    "FirstLastNamePhoneNumberGeoIn": FirstLastNamePhoneNumberGeoIn,
    "FirstLastNamePhoneNumberIn": FirstLastNamePhoneNumberIn,
    "FirstLastNameReligionedOut": FirstLastNameReligionedOut,
    "FirstLastNameSubdivisionIn": FirstLastNameSubdivisionIn,
    "FirstLastNameUSRaceEthnicityOut": FirstLastNameUSRaceEthnicityOut,
    "MatchPersonalFirstLastNameIn": MatchPersonalFirstLastNameIn,
    "NameGeoIn": NameGeoIn,
    "NameIn": NameIn,
    "NameMatchCandidateOut": NameMatchCandidateOut,
    "NameMatchCandidatesOut": NameMatchCandidatesOut,
    "NameMatchedOut": NameMatchedOut,
    "PersonalNameCastegroupOut": PersonalNameCastegroupOut,
    "PersonalNameDiasporaedOut": PersonalNameDiasporaedOut,
    "PersonalNameGenderedOut": PersonalNameGenderedOut,
    "PersonalNameGeoIn": PersonalNameGeoIn,
    "PersonalNameGeoOut": PersonalNameGeoOut,
    "PersonalNameGeoSubclassificationOut": PersonalNameGeoSubclassificationOut,
    "PersonalNameGeoSubdivisionIn": PersonalNameGeoSubdivisionIn,
    "PersonalNameIn": PersonalNameIn,
    "PersonalNameOriginedOut": PersonalNameOriginedOut,
    "PersonalNameParsedOut": PersonalNameParsedOut,
    "PersonalNameReligionedOut": PersonalNameReligionedOut,
    "PersonalNameSubdivisionIn": PersonalNameSubdivisionIn,
    "PersonalNameUSRaceEthnicityOut": PersonalNameUSRaceEthnicityOut,
    "ProperNounCategorizedOut": ProperNounCategorizedOut,
    "RegionISO": RegionISO,
    "RegionOut": RegionOut,
    "ReligionStatOut": ReligionStatOut,
    "SoftwareVersionOut": SoftwareVersionOut,
}

// Check if a string starts with another string without using es6 features
function startsWith(str: string, match: string): boolean {
    return str.substring(0, match.length) === match;
}

// Check if a string ends with another string without using es6 features
function endsWith(str: string, match: string): boolean {
    return str.length >= match.length && str.substring(str.length - match.length) === match;
}

const nullableSuffix = " | null";
const optionalSuffix = " | undefined";
const arrayPrefix = "Array<";
const arraySuffix = ">";
const mapPrefix = "{ [key: string]: ";
const mapSuffix = "; }";

export class ObjectSerializer {
    public static findCorrectType(data: any, expectedType: string) {
        if (data == undefined) {
            return expectedType;
        } else if (primitives.indexOf(expectedType.toLowerCase()) !== -1) {
            return expectedType;
        } else if (expectedType === "Date") {
            return expectedType;
        } else {
            if (enumsMap[expectedType]) {
                return expectedType;
            }

            if (!typeMap[expectedType]) {
                return expectedType; // w/e we don't know the type
            }

            // Check the discriminator
            let discriminatorProperty = typeMap[expectedType].discriminator;
            if (discriminatorProperty == null) {
                return expectedType; // the type does not have a discriminator. use it.
            } else {
                if (data[discriminatorProperty]) {
                    var discriminatorType = data[discriminatorProperty];
                    if(typeMap[discriminatorType]){
                        return discriminatorType; // use the type given in the discriminator
                    } else {
                        return expectedType; // discriminator did not map to a type
                    }
                } else {
                    return expectedType; // discriminator was not present (or an empty string)
                }
            }
        }
    }

    public static serialize(data: any, type: string): any {
        if (data == undefined) {
            return data;
        } else if (primitives.indexOf(type.toLowerCase()) !== -1) {
            return data;
        } else if (endsWith(type, nullableSuffix)) {
            let subType: string = type.slice(0, -nullableSuffix.length); // Type | null => Type
            return ObjectSerializer.serialize(data, subType);
        } else if (endsWith(type, optionalSuffix)) {
            let subType: string = type.slice(0, -optionalSuffix.length); // Type | undefined => Type
            return ObjectSerializer.serialize(data, subType);
        } else if (startsWith(type, arrayPrefix)) {
            let subType: string = type.slice(arrayPrefix.length, -arraySuffix.length); // Array<Type> => Type
            let transformedData: any[] = [];
            for (let index = 0; index < data.length; index++) {
                let datum = data[index];
                transformedData.push(ObjectSerializer.serialize(datum, subType));
            }
            return transformedData;
        } else if (startsWith(type, mapPrefix)) {
            let subType: string = type.slice(mapPrefix.length, -mapSuffix.length); // { [key: string]: Type; } => Type
            let transformedData: { [key: string]: any } = {};
            for (let key in data) {
                transformedData[key] = ObjectSerializer.serialize(
                    data[key],
                    subType,
                );
            }
            return transformedData;
        } else if (type === "Date") {
            return data.toISOString();
        } else {
            if (enumsMap[type]) {
                return data;
            }
            if (!typeMap[type]) { // in case we dont know the type
                return data;
            }

            // Get the actual type of this object
            type = this.findCorrectType(data, type);

            // get the map for the correct type.
            let attributeTypes = typeMap[type].getAttributeTypeMap();
            let instance: {[index: string]: any} = {};
            for (let index = 0; index < attributeTypes.length; index++) {
                let attributeType = attributeTypes[index];
                instance[attributeType.baseName] = ObjectSerializer.serialize(data[attributeType.name], attributeType.type);
            }
            return instance;
        }
    }

    public static deserialize(data: any, type: string): any {
        // polymorphism may change the actual type.
        type = ObjectSerializer.findCorrectType(data, type);
        if (data == undefined) {
            return data;
        } else if (primitives.indexOf(type.toLowerCase()) !== -1) {
            return data;
        } else if (endsWith(type, nullableSuffix)) {
            let subType: string = type.slice(0, -nullableSuffix.length); // Type | null => Type
            return ObjectSerializer.deserialize(data, subType);
        } else if (endsWith(type, optionalSuffix)) {
            let subType: string = type.slice(0, -optionalSuffix.length); // Type | undefined => Type
            return ObjectSerializer.deserialize(data, subType);
        } else if (startsWith(type, arrayPrefix)) {
            let subType: string = type.slice(arrayPrefix.length, -arraySuffix.length); // Array<Type> => Type
            let transformedData: any[] = [];
            for (let index = 0; index < data.length; index++) {
                let datum = data[index];
                transformedData.push(ObjectSerializer.deserialize(datum, subType));
            }
            return transformedData;
        } else if (startsWith(type, mapPrefix)) {
            let subType: string = type.slice(mapPrefix.length, -mapSuffix.length); // { [key: string]: Type; } => Type
            let transformedData: { [key: string]: any } = {};
            for (let key in data) {
                transformedData[key] = ObjectSerializer.deserialize(
                    data[key],
                    subType,
                );
            }
            return transformedData;
        } else if (type === "Date") {
            return new Date(data);
        } else {
            if (enumsMap[type]) {// is Enum
                return data;
            }

            if (!typeMap[type]) { // dont know the type
                return data;
            }
            let instance = new typeMap[type]();
            let attributeTypes = typeMap[type].getAttributeTypeMap();
            for (let index = 0; index < attributeTypes.length; index++) {
                let attributeType = attributeTypes[index];
                instance[attributeType.name] = ObjectSerializer.deserialize(data[attributeType.baseName], attributeType.type);
            }
            return instance;
        }
    }
}

export interface Authentication {
    /**
    * Apply authentication settings to header and query params.
    */
    applyToRequest(requestOptions: localVarRequest.Options): Promise<void> | void;
}

export class HttpBasicAuth implements Authentication {
    public username: string = '';
    public password: string = '';

    applyToRequest(requestOptions: localVarRequest.Options): void {
        requestOptions.auth = {
            username: this.username, password: this.password
        }
    }
}

export class HttpBearerAuth implements Authentication {
    public accessToken: string | (() => string) = '';

    applyToRequest(requestOptions: localVarRequest.Options): void {
        if (requestOptions && requestOptions.headers) {
            const accessToken = typeof this.accessToken === 'function'
                            ? this.accessToken()
                            : this.accessToken;
            requestOptions.headers["Authorization"] = "Bearer " + accessToken;
        }
    }
}

export class ApiKeyAuth implements Authentication {
    public apiKey: string = '';

    constructor(private location: string, private paramName: string) {
    }

    applyToRequest(requestOptions: localVarRequest.Options): void {
        if (this.location == "query") {
            (<any>requestOptions.qs)[this.paramName] = this.apiKey;
        } else if (this.location == "header" && requestOptions && requestOptions.headers) {
            requestOptions.headers[this.paramName] = this.apiKey;
        } else if (this.location == 'cookie' && requestOptions && requestOptions.headers) {
            if (requestOptions.headers['Cookie']) {
                requestOptions.headers['Cookie'] += '; ' + this.paramName + '=' + encodeURIComponent(this.apiKey);
            }
            else {
                requestOptions.headers['Cookie'] = this.paramName + '=' + encodeURIComponent(this.apiKey);
            }
        }
    }
}

export class OAuth implements Authentication {
    public accessToken: string = '';

    applyToRequest(requestOptions: localVarRequest.Options): void {
        if (requestOptions && requestOptions.headers) {
            requestOptions.headers["Authorization"] = "Bearer " + this.accessToken;
        }
    }
}

export class VoidAuth implements Authentication {
    public username: string = '';
    public password: string = '';

    applyToRequest(_: localVarRequest.Options): void {
        // Do nothing
    }
}

export type Interceptor = (requestOptions: localVarRequest.Options) => (Promise<void> | void);
