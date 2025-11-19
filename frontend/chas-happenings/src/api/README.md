# API Architecture Explanation

## 📁 File Structure

```
src/
├── api/
│   ├── axios.js        ← Axios instance with interceptors
│   ├── services.js     ← Organized API calls
│   └── README.md       ← This file
└── pages/
    └── Login/
        └── LoginPage.jsx  ← Uses userAPI.login()
```

## 🔄 How It Works (Step-by-Step)

### 1️⃣ **User Submits Login Form**

```javascript
// In LoginPage.jsx
const token = await userAPI.login(email, password);
```

### 2️⃣ **Service Function is Called**

```javascript
// In services.js
login: async (email, password) => {
  const response = await api.post("/User/LoginUser", { email, password });
  return response.data;
};
```

### 3️⃣ **Request Interceptor Runs (BEFORE request is sent)**

```javascript
// In axios.js - Request Interceptor
api.interceptors.request.use((config) => {
  const token = localStorage.getItem("authToken");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config; // ← Request continues with modified config
});
```

**What happens here:**

- ✅ Gets token from localStorage
- ✅ Adds `Authorization: Bearer <token>` header automatically
- ✅ Logs the request for debugging
- ✅ Applies to ALL requests (login, events, comments, etc.)

### 4️⃣ **Request is Sent to Backend**

```
POST https://localhost:7291/api/User/LoginUser
Headers:
  Content-Type: application/json
  Authorization: Bearer <token> (if exists)
Body:
  { "email": "user@example.com", "password": "password123" }
```

### 5️⃣ **Backend Responds**

```
Status: 201 Created
Body: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." (JWT token)
```

### 6️⃣ **Response Interceptor Runs (AFTER response is received)**

```javascript
// In axios.js - Response Interceptor
api.interceptors.response.use(
  (response) => {
    console.log("Response:", response.status);
    return response; // ← Success, return response
  },
  (error) => {
    if (error.response?.status === 401) {
      localStorage.removeItem("authToken"); // Clear invalid token
    }
    return Promise.reject(error); // ← Pass error to catch block
  }
);
```

**What happens here:**

- ✅ Logs successful responses
- ✅ Handles 401 Unauthorized (expired token)
- ✅ Centralized error handling for ALL requests

### 7️⃣ **Data Returns to LoginPage**

```javascript
// Back in LoginPage.jsx
const token = await userAPI.login(email, password);
localStorage.setItem("authToken", token);
// User is now logged in!
```

---

## 🎯 Key Benefits

### **1. Centralized Configuration**

```javascript
// Change base URL in ONE place (axios.js), affects ALL requests
baseURL: "https://localhost:7291/api";
```

### **2. Automatic Token Handling**

```javascript
// No need to manually add Authorization header to every request
// The interceptor does it automatically!
await api.get("/User/GetAll"); // ← Token added automatically
await api.post("/Event", data); // ← Token added automatically
```

### **3. Consistent Error Handling**

```javascript
// All 401 errors handled in ONE place
if (error.response?.status === 401) {
  localStorage.removeItem("authToken");
  // Could redirect to login
}
```

### **4. Clean Component Code**

```javascript
// Before: Messy
const response = await axios.post(
  "https://localhost:7291/api/User/LoginUser",
  {
    email,
    password,
  },
  {
    headers: { "Content-Type": "application/json" },
  }
);

// After: Clean
const token = await userAPI.login(email, password);
```

### **5. Easy to Mock for Testing**

```javascript
// Mock userAPI.login() instead of mocking axios
jest.mock("../../api/services", () => ({
  userAPI: { login: jest.fn() },
}));
```

---

## 🔍 Real-World Example: Fetching Events

### **Without This Structure:**

```javascript
// EventPage.jsx - BAD
const fetchEvents = async () => {
  const token = localStorage.getItem("authToken");
  const response = await axios.get("https://localhost:7291/api/Event/GetAll", {
    headers: {
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json",
    },
  });
  setEvents(response.data);
};
```

### **With This Structure:**

```javascript
// EventPage.jsx - GOOD
import { eventAPI } from "../../api/services";

const fetchEvents = async () => {
  const events = await eventAPI.getAllEvents();
  setEvents(events);
};
```

**Token is added automatically by the interceptor!** ✨

---

## 🚀 Usage Examples

### **Login**

```javascript
import { userAPI } from "../../api/services";

const token = await userAPI.login("user@example.com", "password123");
localStorage.setItem("authToken", token);
```

### **Fetch Events (Protected Route)**

```javascript
import { eventAPI } from "../../api/services";

// Token automatically added to request!
const events = await eventAPI.getAllEvents();
```

### **Create Event (Protected Route)**

```javascript
import { eventAPI } from "../../api/services";

// Token automatically added to request!
const newEvent = await eventAPI.createEvent({
  title: "Birthday Party",
  date: "2025-12-25",
});
```

### **Handle Errors**

```javascript
try {
  const events = await eventAPI.getAllEvents();
} catch (error) {
  if (error.response?.status === 401) {
    // Interceptor already cleared token
    navigate("/login");
  } else {
    console.error("Error:", error.response?.data);
  }
}
```

---

## 🛠️ Customization

### **Change Base URL**

```javascript
// axios.js
baseURL: "https://your-production-api.com/api";
```

### **Add Request Timeout**

```javascript
// axios.js
timeout: 5000, // 5 seconds
```

### **Add More Interceptors**

```javascript
// axios.js
api.interceptors.request.use((config) => {
  // Add custom headers
  config.headers["X-App-Version"] = "1.0.0";
  return config;
});
```

### **Handle Specific Status Codes**

```javascript
// axios.js - Response Interceptor
if (error.response?.status === 403) {
  alert("You do not have permission to access this resource");
}
```

---

## 📝 Summary

**Flow:**

```
Component → Service → Axios Instance → Request Interceptor → Backend
                                                                 ↓
Component ← Service ← Axios Instance ← Response Interceptor ← Backend
```

**Key Files:**

- `axios.js` = Configuration + Interceptors (automatic token, error handling)
- `services.js` = Organized API functions (clean, reusable)
- `LoginPage.jsx` = Just calls `userAPI.login()` (simple!)

**Result:**
✅ Less code duplication  
✅ Automatic authentication  
✅ Centralized error handling  
✅ Easy to maintain  
✅ Easy to test
