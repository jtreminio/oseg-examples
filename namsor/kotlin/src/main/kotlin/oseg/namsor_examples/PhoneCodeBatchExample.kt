package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map

class PhoneCodeBatchExample
{
    fun phoneCodeBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNamesWithPhoneNumbers1 = FirstLastNamePhoneNumberIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "Jamini",
            lastName = "Roy",
            phoneNumber = "09804201420",
        )

        val personalNamesWithPhoneNumbers = arrayListOf<FirstLastNamePhoneNumberIn>(
            personalNamesWithPhoneNumbers1,
        )

        val batchFirstLastNamePhoneNumberIn = BatchFirstLastNamePhoneNumberIn(
            personalNamesWithPhoneNumbers = personalNamesWithPhoneNumbers,
        )

        try
        {
            val response = SocialApi().phoneCodeBatch(
                batchFirstLastNamePhoneNumberIn = batchFirstLastNamePhoneNumberIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling SocialApi#phoneCodeBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling SocialApi#phoneCodeBatch")
            e.printStackTrace()
        }
    }
}
