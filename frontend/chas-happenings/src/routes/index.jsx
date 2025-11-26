import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../pages/Home/HomePage";
import LoginPage from "../pages/Login/LoginPage";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {
        index: true, // /localhost:3000/ for HomePage
        element: <HomePage />,
      },
      {
        path: "login", // /localhost:5173/login for LoginPage
        element: <LoginPage />,
      },
    ],
  },
]);

export default router;
