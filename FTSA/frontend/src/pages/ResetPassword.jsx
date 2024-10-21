import React, { useState } from 'react';
import axios from 'axios';
import { useLocation } from 'react-router-dom';

export const ResetPassword = () => {
    const [newPassword, setNewPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [message, setMessage] = useState('');
    const [error, setError] = useState('');
    
    const location = useLocation();

    // Lấy token và email từ URL
    const query = new URLSearchParams(location.search);
    const token = query.get('token');
    const email = query.get('email');

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (newPassword !== confirmPassword) {
            setError('Mật khẩu không khớp.');
            return;
        }

        try {
            const response = await axios.post('http://localhost:5145/api/Account/reset-password', {
                email,
                token,
                newPassword
            });
            if (response.status === 200) {
                setMessage("Mật khẩu đã được đổi thành công. Đăng nhập ngay!");
                setError('');
            }
        } catch (err) {
            if (err.response) {
                setError(err.response.data.message || 'Đã xảy ra lỗi');
            } else {
                setError('Đã xảy ra lỗi, vui lòng thử lại sau');
            }
        }
    };

    return (
        <div>
            <h2>Đổi Mật Khẩu</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="password"
                    value={newPassword}
                    onChange={(e) => setNewPassword(e.target.value)}
                    placeholder="Mật khẩu mới"
                    required
                />
                <input
                    type="password"
                    value={confirmPassword}
                    onChange={(e) => setConfirmPassword(e.target.value)}
                    placeholder="Nhập lại mật khẩu"
                    required
                />
                <button type="submit">Đổi Mật Khẩu</button>
                {error && <div>{error}</div>}
                {message && <div>{message}</div>}
            </form>
        </div>
    );
};
