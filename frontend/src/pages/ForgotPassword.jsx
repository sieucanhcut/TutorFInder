import React, { useState } from 'react';
import axios from 'axios';

export const ForgotPassword = () => {
    const [email, setEmail] = useState('');
    const [message, setMessage] = useState('');
    const [error, setError] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post('http://localhost:5145/api/account/forgot-password', { email });
            if (response.status === 200) {
                setMessage("Email reset password đã được gửi, vui lòng kiểm tra hộp thư của bạn.");
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
            <h2>Quên Mật Khẩu</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    placeholder="Nhập email của bạn"
                    required
                />
                <button type="submit">Gửi Email</button>
                {error && <div>{error}</div>}
                {message && <div>{message}</div>}
            </form>
        </div>
    );
};
