import { useState } from "react";
import "./App.css";

function App() {
  const [amount, setAmount] = useState("");
  const [language, setLanguage] = useState("en");
  const [currency, setCurrency] = useState("USD");
  const [result, setResult] = useState("");

async function handleConvert() {
  if (!amount) {
    setResult("Please enter an amount.");
    return;
  }

  try {
    const response = await fetch(
      "http://localhost:5062/api/Conversion",
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          amount: amount,
          language: language,
          currency: currency
        }),
      }
    );

    if (!response.ok) {
      throw new Error("Server error");
    }

    const data = await response.json();

    setResult(data.result);
  }
  catch (error) {
     setResult(error.message);
  }
}

return (
  <div className="container">

    <div className="card">

      <h1>Currency Converter</h1>

      <label>Amount</label>
      <input
        type="text"
        value={amount}
        onChange={(e) => setAmount(e.target.value)}
        placeholder="25,10"
      />


      <label>Language</label>
      <select
        value={language}
        onChange={(e) => setLanguage(e.target.value)}
      >
        <option value="en">English</option>
        <option value="de">German</option>
      </select>


      <label>Currency</label>
      <select
        value={currency}
        onChange={(e) => setCurrency(e.target.value)}
      >
        <option value="USD">US Dollar</option>
        <option value="EUR">Euro</option>
        <option value="GBP">British Pound</option>
      </select>


      <button onClick={handleConvert}>
        Convert
      </button>


      <div className="result">
        {result}
      </div>

    </div>

  </div>
);
}

export default App;