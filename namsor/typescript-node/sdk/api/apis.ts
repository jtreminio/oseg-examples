export * from './adminApi';
import { AdminApi } from './adminApi';
export * from './chineseApi';
import { ChineseApi } from './chineseApi';
export * from './generalApi';
import { GeneralApi } from './generalApi';
export * from './indianApi';
import { IndianApi } from './indianApi';
export * from './japaneseApi';
import { JapaneseApi } from './japaneseApi';
export * from './personalApi';
import { PersonalApi } from './personalApi';
export * from './socialApi';
import { SocialApi } from './socialApi';
import * as http from 'http';

export class HttpError extends Error {
    constructor (public response: http.IncomingMessage, public body: any, public statusCode?: number) {
        super('HTTP request failed');
        this.name = 'HttpError';
    }
}

export { RequestFile } from '../model/models';

export const APIS = [AdminApi, ChineseApi, GeneralApi, IndianApi, JapaneseApi, PersonalApi, SocialApi];
