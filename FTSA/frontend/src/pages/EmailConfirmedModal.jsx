// EmailConfirmedModal.jsx
import React from 'react';
import '../css/EmailConfirmedModal.css'; // Create a CSS file for styling

export const EmailConfirmedModal = ({ isOpen, onClose }) => {
  if (!isOpen) return null;

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>Xác Nhận Email Thành Công!</h2>
        <p>Xin chúc mừng! Tài khoản của bạn đã được xác nhận. Bạn có thể đăng nhập ngay bây giờ.</p>
        <button onClick={onClose}>Đóng</button>
      </div>
    </div>
  );
};

export default EmailConfirmedModal;
