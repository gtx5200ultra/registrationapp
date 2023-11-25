export class ApiResponse<T> {
  statusCode: number;
  data: T;
  errorMessage?: string;

  constructor(statusCode: number, data: T, errorMessage?: string) {
    this.statusCode = statusCode;
    this.data = data;
    this.errorMessage = errorMessage;
  }
}
