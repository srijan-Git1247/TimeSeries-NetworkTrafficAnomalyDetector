The project is to demonstrate time series to detect spikes with SSA algorithm. We will be requiring the Microsoft.ML.TimeSeries NuGet package.

The sampledata.csv file in the Common Folder contains eight rows of network traffic data. Feel free to adjust the data to fit your own observation or to adjust the trained model.
Here is a snippet of the data:

![image](https://github.com/user-attachments/assets/0f4d35e1-43d1-43f4-96f3-ad61162369bb)



Each of these rows contains the value for properties in the NetworkTrafficHistory class. These correspond to HostMachine , TImeStamp and BytesTransferred.


In addition to this, testdata.csv file in the Common Folder contains additional data points to test the newly trained model against and evaluate.
Here is a snippet of the data:


![image](https://github.com/user-attachments/assets/0ca3ffbd-b8a8-4a12-bf98-b510fe4b34eb)






Run the Console Application with commandline arguments:

1. After preparing the data, train the model by passing the data.
> D:\Machine Learning Projects\NetworkTrafficAnomalyDetector\bin\Debug\net8.0 train "D:\Machine Learning Projects\NetworkTrafficAnomalyDetector\Data\sampledata.csv"

![Screenshot 2024-08-21 113541](https://github.com/user-attachments/assets/19e7bf4d-5174-4469-a12a-e176dea13aaf)



2. Run the model with file by simply passing in the testdata.csv into the newly built application and the predicted output will show the following:

   ![Screenshot 2024-08-21 120332](https://github.com/user-attachments/assets/7cb1913f-208c-4c5e-a630-c5c5887920db)



The output includes the three data points: HOST, TIMESTAMP, and TRANSFER. The additions are ALERT, SCORE, and P-VALUE. ALERT values of nonzero indicate an anomaly, SCORE is a numeric representation
of the anomaly score; a higher values indicates a spike. P-VALUE, a value between 0 and 1, is the distance between the current point and the average point. A value closer or equal to 0 is another
indication of spike. When evaluating your model and efficacy, using these three data points together you can be guaranteed a true spike, effectively reducing the possible false positive count.



