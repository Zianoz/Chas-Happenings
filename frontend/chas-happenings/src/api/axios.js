import axios from 'axios';

// Create an axios instance with default configuration
const api = axios.create({
  baseURL: 'https://localhost:7291/api', // Your backend API base URL
  timeout: 10000, // Request timeout in milliseconds (10 seconds)
  headers: {
    'Content-Type': 'application/json',
  },
});

// Request interceptor - runs before every request is sent
api.interceptors.request.use(
  (config) => {
    // Get token from localStorage
    const token = localStorage.getItem('authToken');
    
    // If token exists, add it to the Authorization header
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    
    console.log('Request:', config.method.toUpperCase(), config.url);
    return config;
  },
  (error) => {
    // Handle request errors
    console.error('Request error:', error);
    return Promise.reject(error);
  }
);

// Response interceptor - runs after every response is received
api.interceptors.response.use(
  (response) => {
    // Any status code within the range of 2xx will trigger this function
    console.log('Response:', response.status, response.config.url);
    return response;
  },
  (error) => {
    // Any status codes outside the range of 2xx will trigger this function
    if (error.response) {
      // The request was made and the server responded with a status code
      console.error('Response error:', error.response.status, error.response.data);
      
      // Handle specific error cases
      if (error.response.status === 401) {
        // Unauthorized - token might be expired
        localStorage.removeItem('authToken');
        // Optionally redirect to login page
        // window.location.href = '/login';
      }
    } else if (error.request) {
      // The request was made but no response was received
      console.error('Network error:', error.request);
    } else {
      // Something else happened
      console.error('Error:', error.message);
    }
    
    return Promise.reject(error);
  }
);

export default api;
