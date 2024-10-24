import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import '../css/styles.css';

export const Layout = ({ children }) => {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [dropdownOpen, setDropdownOpen] = useState(false); // State to manage dropdown

    useEffect(() => {
        // Check cookie when component mounts
        const token = localStorage.getItem('auth_token');
        if (token) {
            setIsLoggedIn(true);
        }
    }, []);

    const toggleDropdown = () => {
        setDropdownOpen(!dropdownOpen); // Toggle dropdown visibility
    };

    const handleLogout = () => {
        localStorage.removeItem('auth_token'); // Remove token from localStorage
        setIsLoggedIn(false); // Update login state
        setDropdownOpen(false); // Close dropdown
    };

    return (
        <div className="d-flex flex-column min-vh-100">
            <header>
                <nav className="navbar navbar-expand-lg navbar-light bg-light">
                    <div className="container-fluid">
                        <Link className="navbar-brand" to="/">Tutor Finder</Link>
                        <div style={{ marginBottom: '1rem' }}></div>
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse" id="navbarNav">
                            <ul className="navbar-nav ms-auto">
                                {isLoggedIn ? (
                                    <li className="nav-item dropdown">
                                        <Link className="nav-link" to="#" onClick={toggleDropdown}>
                                            <i className="bi bi-person-circle" style={{ fontSize: '1.5rem' }}></i>
                                        </Link>
                                        {dropdownOpen && ( // Conditionally render dropdown
                                            <ul className="dropdown-menu dropdown-menu-end show" style={{ display: 'block' }}>
                                                <li><Link className="dropdown-item" to="/profile">Profile</Link></li>
                                                <li>
                                                    <Link className="dropdown-item" to="/logout" onClick={handleLogout}>
                                                        Logout
                                                    </Link>
                                                </li>
                                            </ul>
                                        )}
                                    </li>
                                ) : (
                                    <>
                                        <li className="nav-item"><Link className="nav-link" to="/login">Đăng nhập</Link></li>
                                        <li className="nav-item"><Link className="nav-link" to="/register">Đăng ký</Link></li>
                                    </>
                                )}
                            </ul>
                        </div>
                    </div>
                </nav>
            </header>

            <main className="flex-grow-1">
                {children}
            </main>

            <footer className="mt-auto text-center py-4 bg-success text-white">
                <p>© 2024 Tutor Finder. All rights reserved.</p>
                <p>
                    <Link to="#" className="text-white mx-2">Privacy Policy</Link> |
                    <Link to="#" className="text-white mx-2">Terms of Service</Link>
                </p>
            </footer>
        </div>
    );
};
