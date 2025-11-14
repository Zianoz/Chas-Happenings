import { Outlet } from "react-router-dom";
import "./App.css";

function App() {
  return (
    <div className="app">
            {/*Add a navbar that appears on all pages here*/}

      <Outlet /> {/*Pages gets rendered here*/}

            {/*Add a footer that appears on all pages here*/}
    </div>
  );
}

export default App;
