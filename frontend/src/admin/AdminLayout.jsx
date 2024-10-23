// AdminLayout.jsx
import React, { useState, useEffect } from 'react';
import { Outlet } from 'react-router-dom';
import Sidebar from './Sidebar'; // Adjust the import path as necessary
import '../css/AdminLayout.css'; // Import your CSS file for styles

const AdminLayout = () => {
    const [isDarkMode, setIsDarkMode] = useState(false);

    useEffect(() => {
        const savedTheme = localStorage.getItem('theme');
        if (savedTheme) {
            setIsDarkMode(savedTheme === 'dark');
        }
    }, []);

    const toggleTheme = () => {
        setIsDarkMode((prev) => !prev);
        const newTheme = !isDarkMode ? 'dark' : 'light';
        localStorage.setItem('theme', newTheme);
        document.body.className = newTheme; // Change the body class
    };

    return (
        <div className={`admin-layout ${isDarkMode ? 'dark' : 'light'}`} style={{ display: 'flex' }}>
            <Sidebar />
            <div style={{ marginLeft: '10px', padding: '10px', flex: 1 }}>
                <button onClick={toggleTheme} className="btn btn-secondary mb-3">
                    Switch to {isDarkMode ? 'Light' : 'Dark'} Mode
                </button>
                <Outlet />
            </div>
        </div>
    );
};

export default AdminLayout;
