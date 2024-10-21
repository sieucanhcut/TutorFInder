import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

export const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(''); // Clear any previous errors
        setLoading(true); // Set loading state

        try {
            const response = await axios.post('http://localhost:5145/api/Account/login', {
                email,
                password,
            }, { withCredentials: true }); 

            if (response.status === 200) {
                localStorage.setItem('auth_token', response.data.token);
                navigate('/'); 
            }
        } catch (err) {
            setError(err.response?.data.message || 'An error occurred. Please try again.');
        } finally {
            setLoading(false); // Reset loading state
        }
    };

    return (
        <div className="container mt-5">
            <h2 className="text-center text-success">Đăng nhập</h2>
            <form onSubmit={handleSubmit} className="w-50 mx-auto">
                <div className="mb-3">
                    <label className="form-label text-success">Email</label>
                    <input
                        type="email"
                        className="form-control border-success"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>

                <div className="mb-3">
                    <label className="form-label text-success">Mật khẩu</label>
                    <input
                        type="password"
                        className="form-control border-success"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>

                {error && <div className="text-danger mb-3">{error}</div>}

                <div className="d-grid">
                    <button type="submit" className="btn btn-success" disabled={loading}>
                        {loading ? 'Đang đăng nhập...' : 'Đăng nhập'}
                    </button>
                </div>
                <a href="/forgot-password" className="text-decoration-none">Quên Mật Khẩu?</a>
            </form>
        </div>
    );
};
