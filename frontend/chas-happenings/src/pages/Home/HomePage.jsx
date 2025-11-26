import { Link } from "react-router-dom";
import "./HomePage.css";

function HomePage() {
  return (
    <div className="home-container">
      <div className="home-content">
        <h1>Chas Happenings</h1>
        <p>Welcome to the Calendar Application for School Activities</p>
        <nav className="home-nav">
          <Link to="/login" className="nav-button">
            Go to Login
          </Link>
        </nav>
      </div>
    </div>
  );
}

export default HomePage;
