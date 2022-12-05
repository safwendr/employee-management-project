export interface UserInput {
  email?: string,
  password?: string
}

export interface AuthModel {
  accessToken?: string,
  authUser?: {
    id?: number,
    email?: string,
    password?: string
  }
}


