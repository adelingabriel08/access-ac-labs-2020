import axios from "axios";

export const axiosClient = axios.create({
  baseURL: "https://localhost:5001/",
});