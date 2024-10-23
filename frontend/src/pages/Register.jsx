import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useLocation } from 'react-router-dom';
import EmailConfirmedModal from './EmailConfirmedModal';
import '../css/register.css';

export const Register = () => {
  const [role, setRole] = useState('');
  const [showRolePopup, setShowRolePopup] = useState(true);
  const [formData, setFormData] = useState({
    username: '',
    email: '',
    phoneNumber: '',
    password: '',
    confirmPassword: '',
    gender: '',
    birthDate: '',
    location: '',
    PlaceOfWork: '',
    CitizenId: '',
  });

  const [errors, setErrors] = useState({});
  const [generalError, setGeneralError] = useState('');
  const [showEmailPopup, setShowEmailPopup] = useState(false);
  const [popupMessage, setPopupMessage] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const [isEmailConfirmed, setIsEmailConfirmed] = useState(false);

  const location = useLocation();


  const handleRoleSelect = (selectedRole) => {
    setRole(selectedRole);
    setShowRolePopup(false);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));
    setErrors((prevErrors) => ({ ...prevErrors, [name]: null }));
    setGeneralError('');
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setIsLoading(true);
    try {
      const response = await axios.post('http://localhost:5145/api/account/register', {
        ...formData,
        role: role === 'tutor' ? 'Tutor' : 'Student',
      });
      console.log('Registration successful:', response.data);
      setPopupMessage("Email xác nhận tài khoản đã được gửi, vui lòng kiểm tra Gmail của bạn");
      setShowEmailPopup(true);
    } catch (error) {
      console.error('Error registering:', error.response?.data || error.message);
      if (error.response) {
        if (error.response.data.errors) {
          setErrors(error.response.data.errors);
        }
        if (error.response.data.message) {
          setGeneralError(error.response.data.message);
        }
      } else {
        setGeneralError('Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.');
      }
    } finally {
      setIsLoading(false);
    }
  };

  const closeModal = () => {
    setIsEmailConfirmed(false); // Close the email confirmation modal
  };

  const closeEmailPopup = () => {
    setShowEmailPopup(false); // Close the email confirmation popup
  };

  useEffect(() => {
    const params = new URLSearchParams(location.search);
    if (params.get('success') === 'true') {
        setPopupMessage("Xác nhận email thành công!"); 
        setShowEmailPopup(true);
    } else if (params.get('error')) {
        const errorMessage = params.get('errorMessage') || "Có lỗi xảy ra khi xác nhận tài khoản. Vui lòng thử lại.";
        setPopupMessage(errorMessage);
        setShowEmailPopup(true);
    }
    const timer = setTimeout(() => {
        setShowEmailPopup(false); // Tự động ẩn popup sau 5 giây
    }, 5000);

    return () => clearTimeout(timer); // Dọn dẹp timer khi component unmount
}, [location]);

  const Popup = ({ message, onClose }) => {
    return (
      <div className="popup-overlay">
        <div className="popup-content">
          <p>{message}</p>
          <button onClick={onClose}>Đóng</button>
        </div>
      </div>
    );
  };

  return (
    <div className="register-container">
      {showRolePopup && (
        <div className="role-popup">
          <h3>Bạn muốn đăng ký với tư cách là?</h3>
          <button onClick={() => handleRoleSelect('tutor')} className="role-button">Gia Sư</button>
          <button onClick={() => handleRoleSelect('student')} className="role-button">Phụ Huynh, Học Sinh</button>
        </div>
      )}

      {!showRolePopup && (
        <div className="register-form">
          <h2>Đăng ký</h2>
          {generalError && <p className="error-message">{generalError}</p>}

          <form onSubmit={handleSubmit}>
            <label htmlFor="username">Tên Tài Khoản</label>
            <input type="text" name="username" value={formData.username} onChange={handleChange} placeholder="Nhập tên tài khoản" required />
            {errors.username && <p className="error-message">{errors.username[0]}</p>}

            <label htmlFor="email">Email</label>
            <input type="email" name="email" value={formData.email} onChange={handleChange} placeholder="Nhập email" required />
            {errors.email && <p className="error-message">{errors.email[0]}</p>}
            {generalError.includes("Email already exists") && <p className="error-message">Email đã tồn tại.</p>}

            <label htmlFor="phoneNumber">Số điện thoại</label>
            <input type="text" name="phoneNumber" value={formData.phoneNumber} onChange={handleChange} placeholder="Nhập số điện thoại" required />
            {errors.phoneNumber && <p className="error-message">{errors.phoneNumber[0]}</p>}

            <label htmlFor="password">Mật khẩu</label>
            <input type="password" name="password" value={formData.password} onChange={handleChange} placeholder="Nhập mật khẩu" required />
            {errors.password && <p className="error-message">{errors.password[0]}</p>}

            <label htmlFor="confirmPassword">Xác nhận mật khẩu</label>
            <input type="password" name="confirmPassword" value={formData.confirmPassword} onChange={handleChange} placeholder="Xác nhận mật khẩu" required />
            {errors.confirmPassword && <p className="error-message">{errors.confirmPassword[0]}</p>}

            <label>Giới tính</label>
            <div className="gender-options">
              <label><input type="radio" name="gender" value="male" onChange={handleChange} /> Nam</label>
              <label><input type="radio" name="gender" value="female" onChange={handleChange} /> Nữ</label>
              <label><input type="radio" name="gender" value="other" onChange={handleChange} /> Khác</label>
            </div>
            {errors.gender && <p className="error-message">{errors.gender[0]}</p>}

            <label htmlFor="birthDate">Ngày tháng năm sinh</label>
            <input type="date" name="birthDate" value={formData.birthDate} onChange={handleChange} required />
            {errors.birthDate && <p className="error-message">{errors.birthDate[0]}</p>}

            <label htmlFor="location">Địa điểm</label>
            <input type="text" name="location" value={formData.location} onChange={handleChange} placeholder="Nhập địa điểm" required />
            {errors.location && <p className="error-message">{errors.location[0]}</p>}

            <label htmlFor="PlaceOfWork">Nơi làm việc</label>
            <input type="text" name="PlaceOfWork" value={formData.PlaceOfWork} onChange={handleChange} placeholder="Nhập nơi làm việc" required />
            {errors.PlaceOfWork && <p className="error-message">{errors.PlaceOfWork[0]}</p>}

            <label htmlFor="CitizenId">Số CMND</label>
            <input type="text" name="CitizenId" value={formData.CitizenId} onChange={handleChange} placeholder="Nhập số CMND" required />
            {errors.CitizenId && <p className="error-message">{errors.CitizenId[0]}</p>}

            <button type="submit" disabled={isLoading} className="submit-button">
              {isLoading ? 'Đang xử lý...' : 'Đăng ký'}
            </button>
          </form>
        </div>
      )}

      {/* Email confirmation popup */}
      {showEmailPopup && <Popup message={popupMessage} onClose={closeEmailPopup} />}
    </div>
  );
};