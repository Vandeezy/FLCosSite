export interface Identity {
    access_token: string;
    expires_in: number;
    token_type: string;
    expire_date: Date;
    fullName: string;
    userName: string;
    userId: string;
}