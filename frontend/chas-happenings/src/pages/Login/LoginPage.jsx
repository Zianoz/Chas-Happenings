import React, { useState } from "react";
import { userAPI } from "../../api/services";
import "./LoginPage.css";

function LoginPage() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");
    setLoading(true);

    try {
      // Using the userAPI service
      const token = await userAPI.login(email, password);

      // Store the token
      localStorage.setItem("authToken", token);

      console.log("Login successful, token:", token);

      // Redirect or update app state here
      // For example: navigate("/home") or window.location.href = "/home"
    } catch (err) {
      setError(
        err.response?.data || err.message || "An error occurred during login"
      );
      console.error("Login error:", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="login-container">
      <div className="login-card">
        <h1>Chas Happenings</h1>
        <h2>Welcome Back</h2>

        <form onSubmit={handleSubmit} className="login-form">
          {error && <div className="error-message">{error}</div>}
          
          <div className="form-group">
            <label htmlFor="email">Email</label>
            <input
              type="email"
              id="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="Enter your email"
              required
              disabled={loading}
            />
          </div>

          <div className="form-group">
            <label htmlFor="password">Password</label>
            <input
              type="password"
              id="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="Enter your password"
              required
              disabled={loading}
            />
          </div>

          <button type="submit" className="login-button" disabled={loading}>
            {loading ? "Logging in..." : "Log In"}
          </button>
        </form>

        <div className="login-footer">
          <a href="#" className="forgot-password">
            Forgot password?
          </a>
          <p>
            Don't have an account?{" "}
            <a href="#" className="signup-link">
              Sign up
            </a>
          </p>
        </div>
      </div>
    </div>
  );
}

export default LoginPage;
