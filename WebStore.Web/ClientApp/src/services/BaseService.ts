export default abstract class BaseService {
    protected _apiUrl: string;
    constructor(apiUrl?: string) {
    this._apiUrl = apiUrl || "";
    }
    }